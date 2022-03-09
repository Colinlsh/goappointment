using Appointment.Infrastructure.Dtos.Api;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Contracts
{
    public interface IAppointmentCommandService
    {
        /// <summary>
        /// Create appoinment
        /// </summary>
        /// <param name="appointmentDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> CreateAppointmentAsync(AppointmentDto appointmentDto, CancellationToken cancellationToken);

        /// <summary>
        /// Update appointment according to appointment dto status
        /// </summary>
        /// <param name="appointment"></param>
        /// <param name="appointmentDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> UpdateAppointmentAsync(Domain.Tenant.Appointment appointment, AppointmentDto appointmentDto, CancellationToken cancellationToken);
    }
}