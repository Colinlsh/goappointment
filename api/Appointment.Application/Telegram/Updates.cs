using Appointment.Application.Core.Helpers;
using Appointment.Domain.Enums;
using Appointment.Domain.Main;
using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Constants;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using Appointment.Persistence.Extentions;
using Appointment.Persistence.Schema;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

namespace Appointment.Application.Telegram
{
    public class Updates
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Update Update { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ITelegramBotClient botClient;
            private readonly ILogger<Updates> logger;
            private readonly AppointmentMainDataContext mainDataContext;
            private readonly IMemoryCache memoryCache;
            private readonly ITenantAccessor tenantAccessor;
            private readonly IMapper mapper;
            private List<TenantMapping> tenants = new();
            private readonly MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));
            private readonly DateTime cacheEntry = DateTime.Now;

            public Handler(ITelegramBotClient botClient, ILogger<Updates> logger, AppointmentMainDataContext mainDataContext, IMemoryCache memoryCache, ITenantAccessor tenantAccessor, IMapper mapper)
            {
                this.botClient = botClient;
                this.logger = logger;
                this.mainDataContext = mainDataContext;
                this.memoryCache = memoryCache;
                this.tenantAccessor = tenantAccessor;
                this.mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                await EchoAsync(request.Update, cancellationToken);

                return Result<Unit>.Success(Unit.Value);
            }
            private async Task EchoAsync(Update update, CancellationToken cancellationToken)
            {
                // Simulate longer running task
                tenants = memoryCache.Set(nameof(TenantMapping), await mainDataContext.TenantMapping.ToListAsync(cancellationToken), memoryCacheEntryOptions);

                var handler = update.Type switch
                {
                    // UpdateType.Unknown:
                    // UpdateType.ChannelPost:
                    // UpdateType.EditedChannelPost:
                    // UpdateType.ShippingQuery:
                    // UpdateType.PreCheckoutQuery:
                    // UpdateType.Poll:
                    UpdateType.Message => BotOnMessageReceived(update.Message, cancellationToken),
                    UpdateType.EditedMessage => BotOnMessageReceived(update.Message, cancellationToken),
                    UpdateType.CallbackQuery => BotOnCallbackQueryReceived(update.CallbackQuery, cancellationToken),
                    UpdateType.InlineQuery => BotOnInlineQueryReceived(update.InlineQuery),
                    UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(update.ChosenInlineResult),
                    _ => UnknownUpdateHandlerAsync(update)
                };

                try
                {
                    await handler;
                }
                catch (Exception exception)
                {
                    await HandleErrorAsync(exception);
                }
            }

            private async Task BotOnMessageReceived(Message message, CancellationToken cancellationToken)
            {
                logger.LogInformation($"Receive message type: {message.Type}");
                if (message.Type != MessageType.Text)
                    return;

                var action = message.Text.Split(' ').First() switch
                {
                    "/stores" => SendStores(botClient, message, cancellationToken),
                    "/myappointment" => SendMyAppointment(botClient, message),
                    "/bookappointment" => SendBookAppointment(botClient, message, cancellationToken),
                    "/menu" => SendMenu(botClient, message, cancellationToken),
                    _ => Others(botClient, message, cancellationToken)
                };

                var sentMessage = await action;
                logger.LogInformation($"The message was sent with id: {sentMessage.MessageId}");

                // Send inline keyboard
                // You can process responses in BotOnCallbackQueryReceived handler
                async Task<Message> SendStores(ITelegramBotClient bot, Message message, CancellationToken cancellationToken)
                {
                    await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing, cancellationToken);

                    var _tenants = tenants.Select(x => tenantAccessor.GetAppointmentDataContext(x.SchemaName));

                    InlineKeyboardMarkup inlineKeyboard = new(_tenants.Select(x => new[]
                        {
                            InlineKeyboardButton.WithCallbackData($"{x.Store.First().StoreName}", $"{x.Schema}"),
                        }));

                    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                                                      text: "Select a store",
                                                      replyMarkup: inlineKeyboard,
                                                      cancellationToken: cancellationToken);
                }

                async Task<Message> SendMyAppointment(ITelegramBotClient bot, Message message)
                {
                    await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing, cancellationToken);

                    var _tenants = tenants.Select(x => tenantAccessor.GetAppointmentDataContext(x.SchemaName));

                    var telegramAppointments = _tenants.Select(x => x.AppointmentTelegramCustomerProfile.Include(atcp => atcp.Appointment).ThenInclude(z => z.CalendarItem).Include(atcp => atcp.TelegramCustomerProfile).FirstOrDefault(z => z.TelegramCustomerProfile.ChatId == message.Chat.Id));

                    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                                                          text: "",
                                                          cancellationToken: cancellationToken);
                }

                async Task<Message> SendBookAppointment(ITelegramBotClient bot, Message message, CancellationToken cancellationToken)
                {
                    await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing, cancellationToken);

                    return await SendStores(bot, message, cancellationToken);
                }

                async Task<Message> Others(ITelegramBotClient bot, Message message, CancellationToken cancellationToken)
                {
                    await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing, cancellationToken);

                    var returnMessage = string.Empty;

                    var _state = memoryCache.Get<TelegramStateDto>(message.Chat.Id);

                    if (_state != null)
                    {
                        if (!_state.IsStoreSelected)
                            returnMessage = "Please select a store";

                        // check if it is date
                        if (!DateTime.TryParseExact(message.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateResult))
                            returnMessage = "Wrong Date time format";

                        var _selectedTenant = tenants.FirstOrDefault(x => x.HeCode == _state.SelectedTenantHeCode);

                        var _tenants = tenantAccessor.GetAppointmentDataContext(_selectedTenant.SchemaName);

                        var storeInfo = await _tenants.Store.ToListAsync(cancellationToken);

                        if (!_state.IsBookingTimeConfirmed && returnMessage == string.Empty)
                        {
                            returnMessage = $"Booking appointment for {storeInfo[0].StoreName} on the {dateResult.Date.ToShortDateString()}, confirm?";

                            _state.DesiredBookingDate = dateResult;

                            memoryCache.Set(message.Chat.Id, _state);

                            return await SendConfirmation(bot, message.Chat.Id, returnMessage, cancellationToken);
                        }
                    }

                    // hand waving emoji - https://apps.timwhitlock.info/emoji/tables/unicode
                    if (message.Text.Contains("Hi", StringComparison.OrdinalIgnoreCase) && returnMessage == string.Empty)
                        returnMessage = "\U0001F44B";

                    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                                                          text: returnMessage,
                                                          replyMarkup: new ReplyKeyboardRemove(),
                                                          cancellationToken: cancellationToken);
                }

                #region Reference
                //// Send inline keyboard
                //// You can process responses in BotOnCallbackQueryReceived handler
                //static async Task<Message> SendInlineKeyboard(ITelegramBotClient bot, Message message)
                //{
                //    await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                //    // Simulate longer running task
                //    await Task.Delay(500);

                //    InlineKeyboardMarkup inlineKeyboard = new(new[]
                //    {
                //        // first row
                //        new []
                //        {
                //            InlineKeyboardButton.WithCallbackData("1.1", "11"),
                //            InlineKeyboardButton.WithCallbackData("1.2", "12"),
                //        },
                //        // second row
                //        new []
                //        {
                //            InlineKeyboardButton.WithCallbackData("2.1", "21"),
                //            InlineKeyboardButton.WithCallbackData("2.2", "22"),
                //        },
                //    });
                //    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                //                                          text: "Choose",
                //                                          replyMarkup: inlineKeyboard);
                //}

                //static async Task<Message> SendReplyKeyboard(ITelegramBotClient bot, Message message)
                //{
                //    ReplyKeyboardMarkup replyKeyboardMarkup = new(
                //        new KeyboardButton[][]
                //        {
                //            new KeyboardButton[] { "1.1", "1.2" },
                //            new KeyboardButton[] { "2.1", "2.2" },
                //        },
                //        resizeKeyboard: true
                //    );

                //    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                //                                          text: "Choose",
                //                                          replyMarkup: replyKeyboardMarkup);
                //}

                //static async Task<Message> RemoveKeyboard(ITelegramBotClient bot, Message message)
                //{
                //    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                //                                          text: "Removing keyboard",
                //                                          replyMarkup: new ReplyKeyboardRemove());
                //}

                //static async Task<Message> SendFile(ITelegramBotClient bot, Message message)
                //{
                //    await bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

                //    const string filePath = @"Files/tux.png";
                //    using FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                //    var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
                //    return await bot.SendPhotoAsync(chatId: message.Chat.Id,
                //                                    photo: new InputOnlineFile(fileStream, fileName),
                //                                    caption: "Nice Picture");
                //}

                //static async Task<Message> RequestContactAndLocation(ITelegramBotClient bot, Message message)
                //{
                //    ReplyKeyboardMarkup RequestReplyKeyboard = new(new[]
                //    {
                //        KeyboardButton.WithRequestLocation("Location"),
                //        KeyboardButton.WithRequestContact("Contact"),
                //    });
                //    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                //                                          text: "Who or Where are you?",
                //                                          replyMarkup: RequestReplyKeyboard);
                //} 
                #endregion

                static async Task<Message> SendMenu(ITelegramBotClient bot, Message message, CancellationToken cancellationToken)
                {
                    const string usage = "Menu:\n" +
                                         "/bookappointment   - book new appointment\n" +
                                         "/myappointment   - view your upcoming appointment\n";

                    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
                                                          text: usage,
                                                          replyMarkup: new ReplyKeyboardRemove(),
                                                          cancellationToken: cancellationToken);
                }
            }

            private static async Task<Message> SendConfirmation(ITelegramBotClient bot, ChatId chatId, string returnMessage, CancellationToken cancellationToken)
            {
                InlineKeyboardMarkup inlineKeyboard = new(new[]
                {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData($"Confirm", $"{TelegramConstants.ConfirmBooking}"),
                        InlineKeyboardButton.WithCallbackData($"Cancel", $"{TelegramConstants.CancelBooking}")
                    },
                });

                return await bot.SendTextMessageAsync(chatId: chatId,
                                                      text: returnMessage,
                                                      replyMarkup: inlineKeyboard,
                                                      cancellationToken: cancellationToken);
            }

            // Process Inline Keyboard callback data
            private async Task BotOnCallbackQueryReceived(CallbackQuery callbackQuery, CancellationToken cancellationToken)
            {
                var _state = memoryCache.Get<TelegramStateDto>(callbackQuery.Message.Chat.Id);

                if (_state == null)
                    await SendPromptToEnterDesiredDate(callbackQuery);

                if (_state != null)
                {
                    if (callbackQuery.Message.Text == "Select an appointment slot")
                    {
                        await SendConfirmation(botClient, callbackQuery.Message.Chat.Id, $"Confirm appointment on {callbackQuery.Data}?", cancellationToken);
                    }

                    if (callbackQuery.Message.Text.Equals("Select a store", StringComparison.OrdinalIgnoreCase))
                        await SendPromptToEnterDesiredDate(callbackQuery);

                    if (_state.BookedDate == null && _state.DesiredBookingDate == null)
                        await SendPromptToEnterDesiredDate(callbackQuery);

                    if (callbackQuery.Data.Equals(TelegramConstants.ConfirmBooking, StringComparison.OrdinalIgnoreCase) && callbackQuery.Message.Text.Contains("Booking appointment for", StringComparison.OrdinalIgnoreCase))
                    {
                        var selectedTenantMapping = memoryCache.Get<List<TenantMapping>>(nameof(TenantMapping)).FirstOrDefault(x => x.HeCode == _state.SelectedTenantHeCode);
                        // get selected tenant appointments
                        var selectedTenant = tenantAccessor.GetAppointmentDataContext(selectedTenantMapping.SchemaName);

                        var allAppointments = await selectedTenant.Appointment.Include(a => a.CalendarItem).ToListAsync(cancellationToken);

                        var store = await selectedTenant.Store.ToListAsync(cancellationToken);

                        var allDates = Helpers.GetDayInterval(new DateTime(_state.DesiredBookingDate.Value.Year, _state.DesiredBookingDate.Value.Month, _state.DesiredBookingDate.Value.Day, store[0].OperatingStartHour, store[0].OperatingStartMinutes, 0), new DateTime(_state.DesiredBookingDate.Value.Year, _state.DesiredBookingDate.Value.Month, _state.DesiredBookingDate.Value.Day, store[0].OperatingEndHour, store[0].OperatingEndMinutes, 0), 60);

                        InlineKeyboardMarkup inlineKeyboard = new(allDates.Select(x =>
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData($"{x.ToString("dd/MM/yyyy hh:mm tt")}", $"{x}"),
                        }).ToArray());

                        await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                                                              text: "Select an appointment slot",
                                                              replyMarkup: inlineKeyboard,
                                                              cancellationToken: cancellationToken);
                    }
                    else if (callbackQuery.Data.Equals(TelegramConstants.ConfirmBooking, StringComparison.OrdinalIgnoreCase) && callbackQuery.Message.Text.Contains("Confirm appointment", StringComparison.OrdinalIgnoreCase))
                    {
                        //// create appointment
                        var selectedTenantMapping = memoryCache.Get<List<TenantMapping>>(nameof(TenantMapping)).FirstOrDefault(x => x.HeCode == _state.SelectedTenantHeCode);
                        // get selected tenant appointments
                        var selectedTenant = tenantAccessor.GetAppointmentDataContext(selectedTenantMapping.SchemaName);

                        _state.BookedDate = _state.DesiredBookingDate;

                        // create new telegram customer profile
                        var _tgCustomerProfile = new TelegramCustomerProfileDto
                        {
                            ChatId = callbackQuery.Message.Chat.Id,
                            Username = callbackQuery.Message.Chat.Username ?? "",
                            Bio = callbackQuery.Message.Chat.Bio ?? ""
                        };

                        var ctAppointmentStatus = mainDataContext.CTAppointmentStatus.GetFromCache(memoryCache);

                        var appointmentDto = new AppointmentDto
                        {
                            Title = "",
                            Description = "",
                            BookDate = _state.BookedDate.Value,
                            AppointmentStatus = AppointmentStatusType.SCHEDULED.GetDescription(),
                        };

                        appointmentDto.TelegramCustomerProfile.Add(_tgCustomerProfile);

                        var _newAppointment = mapper.Map<Domain.Tenant.Appointment>(appointmentDto);

                        _newAppointment.AppointmentStatusFK = ctAppointmentStatus
                                    .Single(x => x.Code == AppointmentStatusType.SCHEDULED.GetDescription())
                                    .AppointmentStatusId;

                        _newAppointment.IsCancelled = false;
                        _newAppointment.IsRemainderSent = false;
                        _newAppointment.IsCustomerTurnUp = false;
                        _newAppointment.StatusChangeDate = DateTime.Now;
                        _newAppointment.UpdateDate = DateTime.Now;

                        // insert new calendar item
                        var calendarItem = new CalendarItem
                        {
                            StartDateTime = appointmentDto.BookDate,
                            EndDateTime = appointmentDto.BookDate.AddHours(1).AddMinutes(0),
                            DurationHour = 1,
                            DurationMinutes = 0,
                            CreateDate = DateTime.Now,
                            UpdateDate = DateTime.Now
                        };

                        _newAppointment.CalendarItem = calendarItem;

                        _newAppointment.Services = null;
                        _newAppointment.CustomerProfiles = null;
                        if (!selectedTenant.TelegramCustomerProfile.Any(x => x.ChatId == _tgCustomerProfile.ChatId))
                        {
                            var tgCustomerProfile = mapper.Map<TelegramCustomerProfile>(appointmentDto.TelegramCustomerProfile);

                            tgCustomerProfile.Appointments.Add(new AppointmentTelegramCustomerProfile { Appointment = _newAppointment, TelegramCustomerProfile = tgCustomerProfile });
                        }
                        else
                        {
                            var _existedProfile = await selectedTenant.TelegramCustomerProfile.Include(x => x.Appointments).FirstOrDefaultAsync(x => x.ChatId == _tgCustomerProfile.ChatId, cancellationToken);

                            _existedProfile.Appointments.Add(new AppointmentTelegramCustomerProfile { Appointment = _newAppointment, TelegramCustomerProfile = _existedProfile });
                        }

                        await selectedTenant.Appointment.AddAsync(_newAppointment, cancellationToken);

                        var result = await selectedTenant.SaveChangesAsync(cancellationToken) > 0;

                        if (!result)
                            await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                                                              text: "Error creating appointment, please visit GO Appointment website",
                                                              cancellationToken: cancellationToken);

                        await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                                  text: "Booking successful! Enjoy your day!",
                                  cancellationToken: cancellationToken);
                    }

                }

                //var selectedTenantDbContext = _tenantAccessor.GetAppointmentDataContext(selectedTenant.SchemaName);
                //var avaliableAppointment = await selectedTenantDbContext.Appointment.Include(a => a.CalendarItem).ToListAsync(cancellationToken);
            }

            private async Task SendPromptToEnterDesiredDate(CallbackQuery callbackQuery)
            {
                var selectedTenantMapping = memoryCache.Get<List<TenantMapping>>(nameof(TenantMapping)).FirstOrDefault(x => x.SchemaName == callbackQuery.Data);

                var _tenant = tenantAccessor.GetAppointmentDataContext(callbackQuery.Data);

                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id,
                                                     $"Loading appointment slots for: {_tenant.Store.ToArray()[0].StoreName}");

                // set selected store state into cache
                memoryCache.Set(callbackQuery.Message.Chat.Id, new TelegramStateDto { IsStoreSelected = true, SelectedTenantHeCode = selectedTenantMapping.HeCode }, memoryCacheEntryOptions);

                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id,
                                                      $"Please enter your desired date for appointment (eg. 14/08/2022)");
            }

            #region Inline Mode

            private async Task BotOnInlineQueryReceived(InlineQuery inlineQuery)
            {
                logger.LogInformation($"Received inline query from: {inlineQuery.From.Id}");

                InlineQueryResultBase[] results = {
                // displayed result
                new InlineQueryResultArticle(
                    id: "3",
                    title: "TgBots",
                    inputMessageContent: new InputTextMessageContent(
                        "hello"
                    )
                )
            };

                await botClient.AnswerInlineQueryAsync(inlineQueryId: inlineQuery.Id,
                                                        results: results,
                                                        isPersonal: true,
                                                        cacheTime: 0);
            }

            private Task BotOnChosenInlineResultReceived(ChosenInlineResult chosenInlineResult)
            {
                logger.LogInformation($"Received inline result: {chosenInlineResult.ResultId}");
                return Task.CompletedTask;
            }

            #endregion

            private Task UnknownUpdateHandlerAsync(Update update)
            {
                logger.LogInformation($"Unknown update type: {update.Type}");
                return Task.CompletedTask;
            }

            public Task HandleErrorAsync(Exception exception)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };

                logger.LogInformation(ErrorMessage);
                return Task.CompletedTask;
            }
        }
    }
}
