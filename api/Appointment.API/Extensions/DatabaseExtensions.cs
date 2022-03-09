using Appointment.Persistence.Schema;
using Appointment.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Linq;
using Appointment.Persistence.Constants;
using Appointment.Infrastructure.Contracts;

namespace Appointment.API.Extensions
{
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Initialises the tenant mappings.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public static IHost InitialiseTenantMappings(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var memoryCache = scope.ServiceProvider.GetRequiredService<IMemoryCache>();

                using var context = scope.ServiceProvider.GetRequiredService<AppointmentMainDataContext>();

                //Log.Information("Populating TenantMapping memory cache.");

                memoryCache.Set(CacheKeyConstants.TenantMapping,
                    context.TenantMapping.AsNoTracking().ToList(),
                    TimeSpan.FromHours(1));

                //Log.Information("TenantMapping successfully populated in memory cache.");
            }

            return host;
        }

        /// <summary>
        /// Initialises the tenant mappings.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public static IHost InitialiseCTData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var memoryCache = scope.ServiceProvider.GetRequiredService<IMemoryCache>();

                using var context = scope.ServiceProvider.GetRequiredService<AppointmentMainDataContext>();

                memoryCache.Set(CacheKeyConstants.CTAppointmentStatus,
                    context.CTAppointmentStatus.AsNoTracking().ToList(),
                    TimeSpan.FromHours(1));
                memoryCache.Set(CacheKeyConstants.CTCountry,
                    context.CTCountry.AsNoTracking().ToList(),
                    TimeSpan.FromHours(1));
                memoryCache.Set(CacheKeyConstants.CTRace,
                    context.CTRace.AsNoTracking().ToList(),
                    TimeSpan.FromHours(1));
                memoryCache.Set(CacheKeyConstants.CTRelationship,
                    context.CTRelationship.AsNoTracking().ToList(),
                    TimeSpan.FromHours(1));
                memoryCache.Set(CacheKeyConstants.CTReligion,
                    context.CTReligion.AsNoTracking().ToList(),
                    TimeSpan.FromHours(1));
            }

            return host;
        }

        public static IDbContextSchema ConfigureSchema(this IServiceProvider serviceProvider)
        {
            var httpContextService = serviceProvider.GetRequiredService<IHttpContextService>();
            var heCode = httpContextService.GetHeCode();

            var memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();
            var tenantMappings = memoryCache.GetOrCreate(CacheKeyConstants.TenantMapping,
                (cacheEntry) =>
                {
                    //Log.Information("Re-populating TenantMapping memory cache.");

                    try
                    {
                        cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

                        using var scope = serviceProvider.CreateScope();
                        using var context = scope.ServiceProvider.GetRequiredService<AppointmentMainDataContext>();
                        var tenantMappings = context.TenantMapping.AsNoTracking().ToList();

                        //Log.Information("TenantMapping successfully re-populated in memory cache.");

                        return tenantMappings;
                    }
                    catch (Exception ex)
                    {
                        Log.Information(ex, "Unable to re-populate TenantMapping in memory cache.");
                        // For whatever reason, if the connection string is configured wrongly or
                        // the database server experiences downtime, this has to expire quickly
                        // so the correct data will be populated in the cache correctly on recovery.
                        cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5);
                        return null;
                    }
                });

            var currentTenant = tenantMappings?.SingleOrDefault(x => x.HeCode == heCode);

            #region FOR GENERATING MIGRATIONS, COMMENT AWAY AFTER, RMB TO CHANGE BACK DB SETTINGS
            // if (currentTenant is null)
            //     currentTenant = tenantMappings?.SingleOrDefault(x => x.TenantCode == "Tenant_001");
            #endregion
            //Debugger.Launch();
            // There must be a value for the Schema property, else an exception will be thrown.
            // This is so that the database connectivity test can be performed properly without an exception.
            //    private readonly IDbContextSchema _schema;

            //public Initialise(IDbContextSchema schema)
            //{
            //    _schema = schema ?? throw new ArgumentNullException(nameof(schema));
            //}
            //return new DbContextSchema(currentTenant?.SchemaName ?? defaultTenantSchema);
            return new DbContextSchema(currentTenant?.SchemaName ?? "InvalidSchema");
        }
    }
}
