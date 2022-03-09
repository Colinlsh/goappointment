namespace Appointment.Infrastructure.Telegram
{
    public class TelegramBotWebhookService
    {
        //private readonly ITelegramBotClient _botClient;
        //private readonly ILogger<TelegramBotWebhookService> _logger;
        //private readonly AppointmentMainDataContext _mainDataContext;
        //private readonly IMemoryCache _memoryCache;
        //private readonly ITenantAccessor _tenantAccessor;
        //private List<TenantMapping> tenants = new();
        //private readonly MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions()
        //        // Keep in cache for this time, reset time if accessed.
        //        .SetSlidingExpiration(TimeSpan.FromMinutes(5));
        //private readonly DateTime cacheEntry = DateTime.Now;

        //public TelegramBotWebhookService(ITelegramBotClient botClient, ILogger<TelegramBotWebhookService> logger, AppointmentMainDataContext mainDataContext, IMemoryCache memoryCache, ITenantAccessor tenantAccessor)
        //{
        //    _botClient = botClient;
        //    _logger = logger;
        //    _mainDataContext = mainDataContext;
        //    _memoryCache = memoryCache;
        //    _tenantAccessor = tenantAccessor;
        //}

        //public async Task EchoAsync(Update update, CancellationToken cancellationToken)
        //{
        //    // Simulate longer running task
        //    tenants = _memoryCache.Set(nameof(TenantMapping), await _mainDataContext.TenantMapping.ToListAsync(cancellationToken), memoryCacheEntryOptions);

        //    var handler = update.Type switch
        //    {
        //        // UpdateType.Unknown:
        //        // UpdateType.ChannelPost:
        //        // UpdateType.EditedChannelPost:
        //        // UpdateType.ShippingQuery:
        //        // UpdateType.PreCheckoutQuery:
        //        // UpdateType.Poll:
        //        UpdateType.Message => BotOnMessageReceived(update.Message, cancellationToken),
        //        UpdateType.EditedMessage => BotOnMessageReceived(update.Message, cancellationToken),
        //        UpdateType.CallbackQuery => BotOnCallbackQueryReceived(update.CallbackQuery, cancellationToken),
        //        UpdateType.InlineQuery => BotOnInlineQueryReceived(update.InlineQuery),
        //        UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(update.ChosenInlineResult),
        //        _ => UnknownUpdateHandlerAsync(update)
        //    };

        //    try
        //    {
        //        await handler;
        //    }
        //    catch (Exception exception)
        //    {
        //        await HandleErrorAsync(exception);
        //    }
        //}

        //private async Task BotOnMessageReceived(Message message, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation($"Receive message type: {message.Type}");
        //    if (message.Type != MessageType.Text)
        //        return;

        //    var action = message.Text.Split(' ').First() switch
        //    {
        //        "/stores" => SendStores(_botClient, message),
        //        "/myappointment" => SendMyAppointment(_botClient, message),
        //        "/bookappointment" => SendBookAppointment(_botClient, message),
        //        "/menu" => SendMenu(_botClient, message, cancellationToken),
        //        _ => Others(_botClient, message, cancellationToken)
        //    };

        //    var sentMessage = await action;
        //    _logger.LogInformation($"The message was sent with id: {sentMessage.MessageId}");

        //    // Send inline keyboard
        //    // You can process responses in BotOnCallbackQueryReceived handler
        //    async Task<Message> SendStores(ITelegramBotClient bot, Message message)
        //    {
        //        await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing, cancellationToken);

        //        InlineKeyboardMarkup inlineKeyboard = new(tenants.Select(x =>
        //            new[]
        //            {
        //                InlineKeyboardButton.WithCallbackData($"{x.TenantInfo.StoreName}", $"{x.HeCode}"),
        //            }).ToArray());

        //        return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
        //                                              text: "Select a store",
        //                                              replyMarkup: inlineKeyboard,
        //                                              cancellationToken: cancellationToken);
        //    }

        //    async Task<Message> SendMyAppointment(ITelegramBotClient bot, Message message)
        //    {
        //        await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing, cancellationToken);

        //        InlineKeyboardMarkup inlineKeyboard = new(tenants.Select(x =>
        //            new[]
        //            {
        //                InlineKeyboardButton.WithCallbackData($"{x.TenantInfo.StoreName}", $"{x.HeCode}"),
        //            }).ToArray());

        //        return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
        //                                              text: "Select a store",
        //                                              replyMarkup: inlineKeyboard,
        //                                              cancellationToken: cancellationToken);
        //    }

        //    async Task<Message> SendBookAppointment(ITelegramBotClient bot, Message message)
        //    {
        //        await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing, cancellationToken);

        //        return await SendStores(bot, message);
        //    }

        //    async Task<Message> Others(ITelegramBotClient bot, Message message, CancellationToken cancellationToken)
        //    {
        //        await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing, cancellationToken);

        //        var returnMessage = string.Empty;

        //        var _state = _memoryCache.Get<TelegramStateModel>(message.Chat.Id);

        //        if (_state != null)
        //        {
        //            if (!_state.IsStoreSelected)
        //                returnMessage = "Please select a store";

        //            // check if it is date
        //            if (!DateTime.TryParseExact(message.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
        //                returnMessage = "Wrong Date time format";

        //            var _selectedTenant = tenants.FirstOrDefault(x => x.HeCode == _state.SelectedTenantHeCode);

        //            if (!_state.IsBookingTimeConfirmed && returnMessage == string.Empty)
        //            {
        //                returnMessage = $"Booking appointment for {_selectedTenant.TenantInfo.StoreName} on the {result.Date.ToShortDateString()}, confirm?";

        //                InlineKeyboardMarkup inlineKeyboard = new(new[]
        //                {
        //                    // first row
        //                    new []
        //                    {
        //                        InlineKeyboardButton.WithCallbackData($"Confirm", $"{TelegramConstants.ConfirmBooking}"),
        //                        InlineKeyboardButton.WithCallbackData($"Cancel", $"{TelegramConstants.CancelBooking}")
        //                    },
        //                });

        //                return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
        //                                                      text: returnMessage,
        //                                                      replyMarkup: inlineKeyboard,
        //                                                      cancellationToken: cancellationToken);
        //            }
        //        }

        //        // hand waving emoji - https://apps.timwhitlock.info/emoji/tables/unicode
        //        if (message.Text.Contains("Hi", StringComparison.OrdinalIgnoreCase) && returnMessage == string.Empty)
        //            returnMessage = "\U0001F44B"; 

        //        return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
        //                                              text: returnMessage,
        //                                              replyMarkup: new ReplyKeyboardRemove(),
        //                                              cancellationToken: cancellationToken);
        //    }

        //    #region Reference
        //    //// Send inline keyboard
        //    //// You can process responses in BotOnCallbackQueryReceived handler
        //    //static async Task<Message> SendInlineKeyboard(ITelegramBotClient bot, Message message)
        //    //{
        //    //    await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

        //    //    // Simulate longer running task
        //    //    await Task.Delay(500);

        //    //    InlineKeyboardMarkup inlineKeyboard = new(new[]
        //    //    {
        //    //        // first row
        //    //        new []
        //    //        {
        //    //            InlineKeyboardButton.WithCallbackData("1.1", "11"),
        //    //            InlineKeyboardButton.WithCallbackData("1.2", "12"),
        //    //        },
        //    //        // second row
        //    //        new []
        //    //        {
        //    //            InlineKeyboardButton.WithCallbackData("2.1", "21"),
        //    //            InlineKeyboardButton.WithCallbackData("2.2", "22"),
        //    //        },
        //    //    });
        //    //    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
        //    //                                          text: "Choose",
        //    //                                          replyMarkup: inlineKeyboard);
        //    //}

        //    //static async Task<Message> SendReplyKeyboard(ITelegramBotClient bot, Message message)
        //    //{
        //    //    ReplyKeyboardMarkup replyKeyboardMarkup = new(
        //    //        new KeyboardButton[][]
        //    //        {
        //    //            new KeyboardButton[] { "1.1", "1.2" },
        //    //            new KeyboardButton[] { "2.1", "2.2" },
        //    //        },
        //    //        resizeKeyboard: true
        //    //    );

        //    //    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
        //    //                                          text: "Choose",
        //    //                                          replyMarkup: replyKeyboardMarkup);
        //    //}

        //    //static async Task<Message> RemoveKeyboard(ITelegramBotClient bot, Message message)
        //    //{
        //    //    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
        //    //                                          text: "Removing keyboard",
        //    //                                          replyMarkup: new ReplyKeyboardRemove());
        //    //}

        //    //static async Task<Message> SendFile(ITelegramBotClient bot, Message message)
        //    //{
        //    //    await bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

        //    //    const string filePath = @"Files/tux.png";
        //    //    using FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        //    //    var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
        //    //    return await bot.SendPhotoAsync(chatId: message.Chat.Id,
        //    //                                    photo: new InputOnlineFile(fileStream, fileName),
        //    //                                    caption: "Nice Picture");
        //    //}

        //    //static async Task<Message> RequestContactAndLocation(ITelegramBotClient bot, Message message)
        //    //{
        //    //    ReplyKeyboardMarkup RequestReplyKeyboard = new(new[]
        //    //    {
        //    //        KeyboardButton.WithRequestLocation("Location"),
        //    //        KeyboardButton.WithRequestContact("Contact"),
        //    //    });
        //    //    return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
        //    //                                          text: "Who or Where are you?",
        //    //                                          replyMarkup: RequestReplyKeyboard);
        //    //} 
        //    #endregion

        //    static async Task<Message> SendMenu(ITelegramBotClient bot, Message message, CancellationToken cancellationToken)
        //    {
        //        const string usage = "Menu:\n" +
        //                             "/bookappointment   - book new appointment\n" +
        //                             "/myappointment   - view your upcoming appointment\n";

        //        return await bot.SendTextMessageAsync(chatId: message.Chat.Id,
        //                                              text: usage,
        //                                              replyMarkup: new ReplyKeyboardRemove(),
        //                                              cancellationToken: cancellationToken);
        //    }
        //}

        //// Process Inline Keyboard callback data
        //private async Task BotOnCallbackQueryReceived(CallbackQuery callbackQuery, CancellationToken cancellationToken)
        //{
        //    var _state = _memoryCache.Get<TelegramStateModel>(callbackQuery.Message.Chat.Id);

        //    if (_state == null)
        //    {
        //        var selectedTenantMapping = _memoryCache.Get<List<TenantMapping>>(nameof(TenantMapping)).FirstOrDefault(x => x.HeCode == callbackQuery.Data);

        //        await _botClient.AnswerCallbackQueryAsync(callbackQuery.Id,
        //                                             $"Loading appointment slots for: {selectedTenantMapping.TenantInfo.StoreName}");

        //        // set selected store state into cache
        //        _memoryCache.Set(callbackQuery.Message.Chat.Id, new TelegramStateModel { IsStoreSelected = true, SelectedTenantHeCode = selectedTenantMapping.HeCode }, memoryCacheEntryOptions);

        //        await _botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id,
        //                                              $"Please enter your desired date for appointment (eg. 14/08/2022)");

        //        // get selected tenant appointments
        //        var selectedTenant = _tenantAccessor.GetAppointmentDataContext(selectedTenantMapping.SchemaName);

        //        var allAppointments = await selectedTenant.Appointment.Include(a => a.CalendarItem).ToListAsync(cancellationToken);

        //        //var datesInSelectedMonth = GetDates

        //    }

        //    if (callbackQuery.Data.Equals(TelegramConstants.ConfirmBooking, StringComparison.OrdinalIgnoreCase))
        //    {

        //    }

        //    //var selectedTenantDbContext = _tenantAccessor.GetAppointmentDataContext(selectedTenant.SchemaName);
        //    //var avaliableAppointment = await selectedTenantDbContext.Appointment.Include(a => a.CalendarItem).ToListAsync(cancellationToken);
        //}

        //#region Inline Mode

        //private async Task BotOnInlineQueryReceived(InlineQuery inlineQuery)
        //{
        //    _logger.LogInformation($"Received inline query from: {inlineQuery.From.Id}");

        //    InlineQueryResultBase[] results = {
        //        // displayed result
        //        new InlineQueryResultArticle(
        //            id: "3",
        //            title: "TgBots",
        //            inputMessageContent: new InputTextMessageContent(
        //                "hello"
        //            )
        //        )
        //    };

        //    await _botClient.AnswerInlineQueryAsync(inlineQueryId: inlineQuery.Id,
        //                                            results: results,
        //                                            isPersonal: true,
        //                                            cacheTime: 0);
        //}

        //private Task BotOnChosenInlineResultReceived(ChosenInlineResult chosenInlineResult)
        //{
        //    _logger.LogInformation($"Received inline result: {chosenInlineResult.ResultId}");
        //    return Task.CompletedTask;
        //}

        //#endregion

        //private Task UnknownUpdateHandlerAsync(Update update)
        //{
        //    _logger.LogInformation($"Unknown update type: {update.Type}");
        //    return Task.CompletedTask;
        //}

        //public Task HandleErrorAsync(Exception exception)
        //{
        //    var ErrorMessage = exception switch
        //    {
        //        ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        //        _ => exception.ToString()
        //    };

        //    _logger.LogInformation(ErrorMessage);
        //    return Task.CompletedTask;
        //}
    }
}
