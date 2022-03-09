using FluentValidation.AspNetCore;
using Appointment.API.Extensions;
using Appointment.API.Middleware;
using Appointment.API.Options;
using Appointment.Application.AppUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Appointment.Application.Core;

namespace Appointment.API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(opt =>
                {
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    opt.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssemblyContaining<Register>();
                })
                .AddNewtonsoftJson();

            services.AddSwaggerDocument(settings =>
            {
                var swaggerSettings = _config
                    .GetSection(nameof(SwaggerSettings))
                    .Get<SwaggerSettings>();

                settings.Title = swaggerSettings.Title;
                settings.Description = swaggerSettings.Description;
            });
            services.AddApplicationServices(_config);
            services.AddIdentityServices(_config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Register the Swagger generator and the Swagger UI middlewares
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<SerilogMiddleware>();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // Configure custom endpoint per Telegram API recommendations:
                // https://core.telegram.org/bots/api#setwebhook
                // If you'd like to make sure that the Webhook request comes from Telegram, we recommend
                // using a secret path in the URL, e.g. https://www.example.com/<token>.
                // Since nobody else knows your bot's token, you can be pretty sure it's us.
                // ===============================================================================
                // MapControllers() and MapControllerRoute() cannot share the same base controller as MapControllers() will override the settings below
                // Actions are inaccessible via conventional routes defined by UseEndpoints, UseMvc, or UseMvcWithDefaultRoute in Startup.Configure.
                // https://stackoverflow.com/questions/58488727/asp-net-core-3-0-endpoint-routing-doesnt-work-for-default-route
                var token = _config.GetSection("TelegramBot").Get<BotConfiguration>().BotToken;
                endpoints.MapControllerRoute(name: "TelegramWebhook",
                                             pattern: $"api/telegramwebhook/bot/{token}",
                                             defaults: new { controller = "TelegramWebhook", action = "Update" });
            });
        }
    }
}
