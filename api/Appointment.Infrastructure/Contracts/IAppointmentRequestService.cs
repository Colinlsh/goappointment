using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Dtos.Api;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Contracts
{
    public interface IAppointmentRequestService
    {
        /// <summary>
        /// Returns a current list of appointments in dto format
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IList<AppointmentDto>> GetAppointmentDtosAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Returns appointment by title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Domain.Tenant.Appointment> GetAppointment_ByTitleAsync(string title, CancellationToken cancellationToken);

        /// <summary>
        /// Returns appointment by appointmentid
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Domain.Tenant.Appointment> GetAppointment_ByAppointmentIDAsync(Guid appointmentId, CancellationToken cancellationToken);
        Task<IList<CalendarItem>> GetCalendarItems_BySelectedDateAsync(DateTime bookedDate, CancellationToken cancellationToken);
    }
}