using Appointment.Application.Core.Interfaces;
using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using Appointment.Persistence.Extentions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Appointment
{
    public class AppointmentRequestService : IAppointmentRequestService
    {
        private readonly AppointmentDataContext _context;
        private readonly AppointmentMainDataContext _mainDataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AppointmentRequestService> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IServicesRequestService _servicesRequestService;

        public AppointmentRequestService(AppointmentDataContext context, AppointmentMainDataContext mainDataContext, IMapper mapper, ILogger<AppointmentRequestService> logger, IMemoryCache memoryCache)
        {
            _context = context;
            _mainDataContext = mainDataContext;
            _mapper = mapper;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public async Task<IList<AppointmentDto>> GetAppointmentDtosAsync(CancellationToken cancellationToken)
        {
            var appointments = await _context.Appointment
                .Include(a => a.CalendarItem)
                .Include(a => a.CustomerProfiles).ThenInclude(a => a.CustomerProfile)
                .Include(a => a.Services).ThenInclude(a => a.Service).ThenInclude(a => a.ServiceItems).ThenInclude(a => a.ServiceItem)
                .Include(a => a.TelegramCustomerProfile).ThenInclude(a => a.TelegramCustomerProfile)
                .ToListAsync(cancellationToken);

            return appointments.Select(a =>
            {
                var serviceDtos = a.Services.Select(x =>
                {
                    var serviceItemDtos = _mapper.Map<IList<ServiceItemDto>>(x.Service.ServiceItems.Select(si => si.ServiceItem));

                    return new ServiceDto
                    {
                        Id = x.Service.Id,
                        Title = x.Service.Title,
                        Description = x.Service.Description,
                        ServiceItemDtos = serviceItemDtos
                    };
                }).ToList();

                var customerProfileDtos = _mapper.Map<IList<CustomerProfileDto>>(a.CustomerProfiles.Select(cp => cp.CustomerProfile));
                var appointmentStatus = _mainDataContext.CTAppointmentStatus
                                                        .GetFromCache(_memoryCache)
                                                        .First(aps => aps.AppointmentStatusId == a.AppointmentStatusFK).Code;
                var appointmentDto = new AppointmentDto
                {
                    Title = a.Title,
                    Description = a.Description,
                    Id = a.Id,
                    BookDate = a.BookDate,
                    AppointmentStatus = appointmentStatus,
                    ServiceDtos = serviceDtos,
                    CustomerProfileDtos = customerProfileDtos,
                    TelegramCustomerProfile = _mapper.Map<IList<TelegramCustomerProfileDto>>(a.TelegramCustomerProfile.Select(tg => tg.TelegramCustomerProfile))
                };
                return appointmentDto;
            }).ToList();
        }

        public async Task<Domain.Tenant.Appointment> GetAppointment_ByTitleAsync(string title, CancellationToken cancellationToken)
        {
            return await _context.Appointment
                        .SingleOrDefaultAsync(a => a.Title == title, cancellationToken);
        }

        public async Task<Domain.Tenant.Appointment> GetAppointment_ByAppointmentIDAsync(Guid appointmentId, CancellationToken cancellationToken)
        {
            return await _context.Appointment
                .SingleOrDefaultAsync(x => x.Id == appointmentId, cancellationToken);
        }

        public async Task<IList<CalendarItem>> GetCalendarItems_BySelectedDateAsync(DateTime bookedDate, CancellationToken cancellationToken)
        {
            return await _context.CalendarItem.Where(x => x.StartDateTime.Date == bookedDate.Date).ToListAsync(cancellationToken);
        }
    }
}
