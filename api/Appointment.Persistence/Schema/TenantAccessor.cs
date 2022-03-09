using Appointment.Domain.Tenant;
using Appointment.Persistence.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appointment.Persistence.Schema
{
    public class TenantAccessor : ITenantAccessor, IDisposable
    {
        private readonly IMemoryCache _memoryCache;
        private readonly DbContextOptions<AppointmentDataContext> _options;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AppointmentDataContext> _logger;
        private readonly AppointmentMainDataContext _mainDataContext;

        public List<AppointmentDataContext> DbList { get; private set; } = new List<AppointmentDataContext>();
        public List<string> Tenants { get; }


        public TenantAccessor(IMemoryCache memoryCache, DbContextOptions<AppointmentDataContext> options, IServiceProvider serviceProvider, ILogger<AppointmentDataContext> logger, AppointmentMainDataContext mainDataContext)
        {
            _memoryCache = memoryCache;
            _options = options;
            _serviceProvider = serviceProvider;
            _logger = logger;
            _mainDataContext = mainDataContext;

            Tenants = _mainDataContext.TenantMapping.GetFromCache(_memoryCache).Select(x => x.TenantCode).ToList();
        }

        public AppointmentDataContext GetAppointmentDataContext(string schema)
        {
            if (DbList.Any(x => x.Schema == schema))
                return DbList.FirstOrDefault(x => x.Schema == schema);

            var _newDb = new AppointmentDataContext(_memoryCache, _options, _serviceProvider, _logger, new DbContextSchema(schema));

            DbList.Add(_newDb);

            return _newDb;
        }

        /// <summary>
        /// Method to return key value pair consist of HeCode and Appuser, validating using email
        /// </summary>
        /// <param name="username"></param>
        /// <returns>HeCode, AppUser</returns>
        public Dictionary<string, AppUser> GetAllUsersByEmail(string email)
        {
            var _tenantMapping = _mainDataContext.TenantMapping.GetFromCache(_memoryCache);

            return DbList.ToDictionary(x => _tenantMapping.FirstOrDefault(z => z.TenantCode == x.Schema).HeCode,
                                        x => x.AppUser.Include(ap => ap.UserProfile).FirstOrDefault());
        }

        /// <summary>
        /// Method to return key value pair consist of HeCode and Appuser, validating using username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>HeCode, AppUser</returns>
        public Dictionary<string, AppUser> GetAllUsersByUsername(string username)
        {
            var _tenantMapping = _mainDataContext.TenantMapping.GetFromCache(_memoryCache);

            return DbList.ToDictionary(x => _tenantMapping.FirstOrDefault(z => z.TenantCode == x.Schema).HeCode,
                                        x => x.AppUser.Include(ap => ap.UserProfile)
                                                        .FirstOrDefault(z => z.Username == username));
        }

        /// <summary>
        /// Method to return key value pair consist of HeCode and Telegram User, validating using chatid
        /// </summary>
        /// <param name="username"></param>
        /// <returns>HeCode, AppUser</returns>
        public Dictionary<string, AppointmentTelegramCustomerProfile> GetAllTelegramCustomerAppointmentsByChatId(long chatId)
        {
            var _tenantMapping = _mainDataContext.TenantMapping.GetFromCache(_memoryCache);

            return DbList.ToDictionary(x => _tenantMapping.FirstOrDefault(z => z.TenantCode == x.Schema).HeCode,
                                        x => x.AppointmentTelegramCustomerProfile.Include(tcp => tcp.Appointment).ThenInclude(a => a.CalendarItem).Include(tcp => tcp.TelegramCustomerProfile).FirstOrDefault(x => chatId.Equals(x.TelegramCustomerProfile.ChatId)));
        }

        public void Dispose()
        {
            DbList.Clear();
            DbList = null;
        }
    }
}
