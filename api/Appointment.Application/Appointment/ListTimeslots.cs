using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Appointment
{
    public class ListTimeslots
    {

        public class Query : IRequest<Result<IList<TimeslotDto>>>
        {
            public DateTime SelectedDate { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<IList<TimeslotDto>>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;
            private readonly IAppointmentRequestService _appointmentRequestService;

            public Handler(AppointmentDataContext context, IMapper mapper, IAppointmentRequestService appointmentRequestService)
            {
                _context = context;
                _mapper = mapper;
                _appointmentRequestService = appointmentRequestService;
            }

            public async Task<Result<IList<TimeslotDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var store = await _context.Store
                                    .Include(x => x.OffDays)
                                    .Include(x => x.SpecialOffDays)
                                    .FirstAsync(cancellationToken);

                var calendarItems = await _appointmentRequestService.GetCalendarItems_BySelectedDateAsync(request.SelectedDate, cancellationToken);

                // get total working hours

                var timeSpan = new DateTime(2099, 1, 1, store.OperatingEndHour, store.OperatingEndMinutes, 0) - new DateTime(2099, 1, 1, store.OperatingStartHour, store.OperatingStartMinutes, 0);

                var totalWorkingMinutes = timeSpan.TotalMinutes;

                var _timeslots = new List<TimeslotDto>();
                var newTimeslot = new DateTime(2099, 1, 1, store.OperatingStartHour, store.OperatingStartMinutes, 0);

                for (int i = 0; i < timeSpan.TotalHours; i++)
                {
                    _timeslots.Add(new TimeslotDto { Time = newTimeslot });
                    newTimeslot = newTimeslot.AddHours(1);
                }

                // if there are no items on that day.
                if (!calendarItems.Any())
                    return Result<IList<TimeslotDto>>.Success(_timeslots);

                // compare with services per hour
                var groupedCalendarItems = calendarItems.GroupBy(x => x.StartDateTime.Hour);

                var result = groupedCalendarItems.ToLookup(x => x);

                var newTimeSlots = _timeslots;

                foreach (var timeslot in _timeslots)
                {
                    var serviceDuration = 0;
                    var isNoMoreTimeSlot = groupedCalendarItems.Any(x =>
                    {
                        return x.Any(z =>
                        {
                            serviceDuration += z.DurationMinutes;
                            serviceDuration += z.DurationHour * 60;

                            if (z.StartDateTime.TimeOfDay >= timeslot.Time.TimeOfDay && z.StartDateTime.TimeOfDay <= timeslot.Time.AddHours(1).TimeOfDay)
                            {
                                if (serviceDuration > (store.ServiceHoursPerHour * 60))
                                    return true;
                            }

                            return false;
                        });
                    });

                    if (!isNoMoreTimeSlot)
                        newTimeSlots.Remove(timeslot);
                }

                return Result<IList<TimeslotDto>>.Success(newTimeSlots);
            }
        }

    }
}
