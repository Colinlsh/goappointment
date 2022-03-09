using Appointment.Application.AppUser;
using Appointment.Application.Core;
using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Photos;
using Appointment.Persistence.Schema;
using Appointment.Infrastructure.Security;
using Appointment.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Appointment.Infrastructure.Email;
using Telegram.Bot;
using Appointment.Infrastructure.Appointment;
using Appointment.Infrastructure.Services;
using Appointment.Infrastructure.Store;
using Appointment.Infrastructure.AppUser;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.AdminUser;
using Appointment.Infrastructure.Aws.Api;

namespace Appointment.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IHttpContextService, HttpContextService>();

            services.AddMemoryCache();

            services.AddMediatR(typeof(List.Handler).Assembly);

            services.AddAutoMapper(typeof(ProfileBase).Assembly);
            services.AddHttpClient<IHttpClientService, HttpClientService>();

            // services.ConfigureApplicationCookie(options =>
            // {
            //     // Cookie settings
            //     options.Cookie.HttpOnly = true;
            //     options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //     options.SlidingExpiration = true;
            // });

            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));
            services.AddScoped<IPhotoAccessorService, PhotoAccessorService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped<IAppointmentRequestService, AppointmentRequestService>();
            services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();
            services.AddScoped<IServicesCommandService, ServicesCommandService>();
            services.AddScoped<IServicesRequestService, ServicesRequestService>();
            services.AddScoped<IStoreCommandService, StoreCommandService>();
            services.AddScoped<IStoreRequestService, StoreRequestService>();
            services.AddScoped<IAppUserRequestService, AppUserRequestService>();

            services.AddScoped<IAdminUserCommandService, AdminUserCommandService>();
            services.AddScoped<IAwsApiCommandService, AwsApiCommandService>();

            services.AddDbContext<AppointmentMainDataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            // https://www.thinktecture.com/en/entity-framework-core/changing-database-schema-at-runtime-in-2-1/
            // https://www.thinktecture.com/en/entity-framework-core/changing-db-migration-schema-at-runtime-in-2-1/
            services.AddDbContext<AppointmentDataContext>(opt =>
            {
                var connectionString = config.GetConnectionString("DefaultConnection");

                Console.WriteLine(connectionString);

                opt.UseSqlServer(connectionString)
                    .ReplaceService<IModelCacheKeyFactory, DbSchemaAwareModelCacheKeyFactory>()
                    .ReplaceService<IMigrationsAssembly, DbSchemaAwareMigrationAssembly>();
            })
                .AddScoped(serviceProvider => serviceProvider.ConfigureSchema())
                .AddScoped<ITenantAccessor, TenantAccessor>();

            services.AddDbContext<AppointmentLoggingDataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("Logging"));
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .WithExposedHeaders("WWW-Authenticate");
                });
            });
            // bot services
            // Register named HttpClient to get benefits of IHttpClientFactory
            // and consume it with ITelegramBotClient typed client.
            // More read:
            //  https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0#typed-clients
            //  https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests

            var _botConfig = config.GetSection("TelegramBot").Get<BotConfiguration>();
            services.AddHttpClient("TelegramWebhook")
                    .AddTypedClient<ITelegramBotClient>(httpClient
                        => new TelegramBotClient(_botConfig.BotToken, httpClient));

            // There are several strategies for completing asynchronous tasks during startup.
            // Some of them could be found in this article https://andrewlock.net/running-async-tasks-on-app-startup-in-asp-net-core-part-1/
            // We are going to use IHostedService to add and later remove Webhook
            // IHostedService will implement registered service into background task.
            services.AddHostedService<ConfigureTelegramWebhook>();

            // Dummy business-logic service
            //services.AddScoped<ITelegramBotWebhookService, TelegramBotWebhookService>();

            return services;
        }
    }
}
