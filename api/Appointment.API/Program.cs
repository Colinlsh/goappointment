using System;
using System.Linq;
using System.Threading.Tasks;
using Appointment.API.Extensions;
using Appointment.Domain;
using Appointment.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Appointment.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(config)
                            .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                            .CreateLogger();

            var host = CreateHostBuilder(args)
                    .Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppointmentDataContext>();
                var mainDataContext = services.GetRequiredService<AppointmentMainDataContext>();

                var mainDBPendingMigrations = await mainDataContext.Database.GetPendingMigrationsAsync();

                if (mainDBPendingMigrations.Any())
                    await mainDataContext.Database.MigrateAsync();

                await Seed.SeedData(context, mainDataContext);
                Log.Information("Starting application.");

                await host
                    .InitialiseTenantMappings()
                    .InitialiseCTData()
                    .RunAsync();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "An error occured during migration");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
