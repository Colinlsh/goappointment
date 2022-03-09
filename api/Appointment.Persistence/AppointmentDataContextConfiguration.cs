using Appointment.Domain.Main;
using Appointment.Persistence.Constants;
using Appointment.Persistence.Schema;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appointment.Persistence
{
    public partial class AppointmentDataContext : DbContext, IDbContextSchema
    {
        public string Schema { get; set; }

        #region Private Members
        private readonly IMemoryCache _memoryCache;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AppointmentDataContext> _logger;

        #endregion

        #region Constructor

        public AppointmentDataContext(IMemoryCache memoryCache, DbContextOptions<AppointmentDataContext> options, IServiceProvider serviceProvider, ILogger<AppointmentDataContext> logger, IDbContextSchema dbContextSchema = null) : base(options)
        {
            Schema = dbContextSchema?.Schema;
            _memoryCache = memoryCache
                ?? throw new ArgumentNullException(nameof(memoryCache));
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        #endregion

        #region Public Methods
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Schema == "InvalidSchema")
            {
                //Debugger.Launch();
                optionsBuilder.UseSqlServer(GetConnectionString(), x => x.MigrationsHistoryTable("__EFMigrationsHistory", "AppointmentMain"));
                return;
            }

            var tenantMappings = _memoryCache.Get<List<TenantMapping>>(CacheKeyConstants.TenantMapping);
            var currentTenant = tenantMappings?.SingleOrDefault(x => x.SchemaName == Schema);
            #region FOR GENERATING MIGRATIONS, COMMENT AWAY AFTER, RMB TO CHANGE BACK DB SETTINGS
            //if (currentTenant is null)
            //{
            //    tenantMappings = _memoryCache.GetOrCreate(CacheKeyConstants.TenantMapping,
            //    (cacheEntry) =>
            //    {
            //        _logger.LogInformation("Re-populating TenantMapping memory cache.");

            //        try
            //        {
            //            cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

            //            using var scope = _serviceProvider.CreateScope();
            //            using var context = scope.ServiceProvider.GetRequiredService<AppointmentMainDataContext>();
            //            var tenantMappings = context.TenantMapping.AsNoTracking().ToList();

            //            _logger.LogInformation("TenantMapping successfully re-populated in memory cache.");

            //            return tenantMappings;
            //        }
            //        catch (Exception ex)
            //        {
            //            _logger.LogInformation(ex, "Unable to re-populate TenantMapping in memory cache.");
            //            // For whatever reason, if the connection string is configured wrongly or
            //            // the database server experiences downtime, this has to expire quickly
            //            // so the correct data will be populated in the cache correctly on recovery.
            //            cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5);
            //            return null;
            //        }
            //    });
            //    currentTenant = tenantMappings?.SingleOrDefault(x => x.SchemaName == Schema);
            //}
            #endregion

            var option = optionsBuilder.Options.GetExtension<SqlServerOptionsExtension>();

            optionsBuilder.UseSqlServer(GetConnectionString(option.ConnectionString, currentTenant), x => x.MigrationsHistoryTable("__EFMigrationsHistory", currentTenant.SchemaName));

            //optionsBuilder.UseSqlServer(GetConnectionString(option.ConnectionString, currentTenant));
        }
        #endregion

        private static string GetConnectionString(
            string originalConnectionString = default,
            TenantMapping tenantMapping = default)
        {
            var builder = new SqlConnectionStringBuilder();

            if (originalConnectionString is not null && tenantMapping is not null)
            {
                builder.ConnectionString = originalConnectionString;
                builder.DataSource = tenantMapping.DBServer;
                builder.InitialCatalog = tenantMapping.DBName;

                // Just stick to the superadmin credentials from the initial connection string.
                //builder.UserID = tenantMapping.DBUserName;
                //builder.Password = tenantMapping.DBUserPassword;
            }
            else
            {
                builder.DataSource = string.Empty;
                builder.InitialCatalog = string.Empty;
            }
            return builder.ConnectionString;
        }
    }
}
