using Appointment.Application.Core.Interfaces;
using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using Appointment.Persistence.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Appointment.Infrastructure.Services
{
    public class ServicesRequestService : IServicesRequestService
    {
        private readonly AppointmentDataContext _context;
        private readonly ILogger<ServicesRequestService> _logger;
        private readonly IMemoryCache _memoryCache;

        public ServicesRequestService(AppointmentDataContext context, ILogger<ServicesRequestService> logger, IMemoryCache memoryCache)
        {
            _context = context;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public IList<Service> GetServices_ByServiceDtoID(IList<ServiceDto> serviceDto)
        {
            return _context.Service
                            .Include(s => s.ServiceItems).ThenInclude(si => si.ServiceItem)
                            .GetFromCache(_memoryCache)
                            .FindAll(s => serviceDto.Any(si => si.Id == s.Id));
        }
    }
}
