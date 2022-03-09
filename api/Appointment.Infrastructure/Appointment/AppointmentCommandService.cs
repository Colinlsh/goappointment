using Appointment.Application.Core.Interfaces;
using Appointment.Domain.Enums;
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
    public class AppointmentCommandService : IAppointmentCommandService
    {
        private readonly AppointmentDataContext _context;
        private readonly AppointmentMainDataContext _mainDataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AppointmentCommandService> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IServicesRequestService _servicesRequestService;

        public AppointmentCommandService(AppointmentDataContext context, AppointmentMainDataContext mainDataContext, IMapper mapper, ILogger<AppointmentCommandService> logger, IMemoryCache memoryCache, IServicesRequestService servicesRequestService)
        {
            _context = context;
            _mainDataContext = mainDataContext;
            _mapper = mapper;
            _logger = logger;
            _memoryCache = memoryCache;
            _servicesRequestService = servicesRequestService;
        }

        public async Task<bool> CreateAppointmentAsync(AppointmentDto appointmentDto, CancellationToken cancellationToken)
        {
            var _newAppointment = _mapper.Map<Domain.Tenant.Appointment>(appointmentDto);

            var ctAppointmentStatus = _mainDataContext.CTAppointmentStatus.GetFromCache(_memoryCache);

            _newAppointment.AppointmentStatusFK = ctAppointmentStatus
                                                .Single(x => x.Code == AppointmentStatusType.SCHEDULED.GetDescription())
                                                .AppointmentStatusId;

            _newAppointment.IsCancelled = false;
            _newAppointment.IsRemainderSent = false;
            _newAppointment.IsCustomerTurnUp = false;
            _newAppointment.StatusChangeDate = DateTime.Now;
            _newAppointment.UpdateDate = DateTime.Now;

            // look for the services
            var services = _servicesRequestService.GetServices_ByServiceDtoID(appointmentDto.ServiceDtos.ToList());

            // calculate total duration in terms of hour and minutes
            var fullDurationHours = services.SelectMany(x => x.ServiceItems).Sum(si => si.ServiceItem.DurationHour);
            var fullDurationMinutes = services.SelectMany(x => x.ServiceItems).Sum(si => si.ServiceItem.DurationMinutes);

            if (fullDurationMinutes >= 60)
            {
                fullDurationHours += Math.Abs(fullDurationMinutes / 60);
                fullDurationMinutes -= 60;
            }

            // insert new calendar item
            var calendarItem = new CalendarItem
            {
                StartDateTime = appointmentDto.BookDate,
                EndDateTime = appointmentDto.BookDate.AddHours(fullDurationHours).AddMinutes(fullDurationMinutes),
                DurationHour = fullDurationHours,
                DurationMinutes = fullDurationMinutes,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            _newAppointment.CalendarItem = calendarItem;

            // add services into appointment
            _newAppointment.Services = new List<AppointmentService>();

            foreach (var item in services)
            {
                // https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/april/data-points-why-does-entity-framework-reinsert-existing-objects-into-my-database
                // this particular line is to prevent EF CORE from setting the current service entity as a new entity. Because by default, _context.Add will tag the entire parent to child object to an ADD state instead of UNCHANGED for exisitng entity. After which it will attempt to insert a new entity resulting in PK constraint error
                _context.Entry(item).State = EntityState.Unchanged;
                _newAppointment.Services.Add(new AppointmentService { Appointment = _newAppointment, Service = item });
            }

            // customer profiles
            // check customer exist or not
            _newAppointment.CustomerProfiles = new List<AppointmentCustomerProfile>();
            if (!_context.CustomerProfile.GetFromCache(_memoryCache).Any())
            {
                var customerProfiles = _mapper.Map<List<CustomerProfile>>(appointmentDto.CustomerProfileDtos);

                // add join table items
                foreach (var item in customerProfiles)
                {
                    _newAppointment.CustomerProfiles.Add(new AppointmentCustomerProfile { CustomerProfile = item, Appointment = _newAppointment });
                };
            }
            else
            {
                // get old customer profiles
                var oldCustomerProfiles = await _context.CustomerProfile
                    .Include(cp => cp.Appointments)
                    .ToListAsync(cancellationToken);

                // validate if sent in customer is new or not.
                var newCustomerProfileDtos = appointmentDto.CustomerProfileDtos
                        .Where(x => oldCustomerProfiles.Any(cps => cps.Email != x.Email));

                // map to customer profile entity
                var newCustomerProfiles = _mapper.Map<IList<CustomerProfile>>(newCustomerProfileDtos);

                // select old profiles and return join table entity, set old customer profile entity to unchanged to prevent new insertion.
                var appointmentCustomerProfiles = oldCustomerProfiles
                    .FindAll(x => appointmentDto.CustomerProfileDtos.Any(cps => cps.Email == x.Email))
                    .Select(x =>
                    {
                        _context.Entry(x).State = EntityState.Unchanged;
                        return new AppointmentCustomerProfile
                        {
                            Appointment = _newAppointment,
                            CustomerProfile = x
                        };
                    }).ToList();

                // insert new customer profiles
                appointmentCustomerProfiles.AddRange(newCustomerProfiles.Select(x => new AppointmentCustomerProfile
                {
                    Appointment = _newAppointment,
                    CustomerProfile = x
                }));

                // add join table items
                foreach (var item in appointmentCustomerProfiles)
                {
                    _newAppointment.CustomerProfiles.Add(item);
                };
            }

            _context.Appointment.Add(_newAppointment);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateAppointmentAsync(Domain.Tenant.Appointment appointment, AppointmentDto appointmentDto, CancellationToken cancellationToken)
        {
            var newStatusCodeId = _mainDataContext.CTAppointmentStatus
                .GetFromCache(_memoryCache)
                .First(x => x.Code == appointmentDto.AppointmentStatus).AppointmentStatusId;

            // update status change date if appointment status changed
            if (newStatusCodeId != appointment.AppointmentStatusFK)
                appointment.StatusChangeDate = DateTime.Now;

            appointment.AppointmentStatusFK = newStatusCodeId;
            appointment.UpdateDate = DateTime.Now;

            _mapper.Map(appointmentDto, appointment);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
