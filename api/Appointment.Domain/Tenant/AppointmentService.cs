using System;

namespace Appointment.Domain.Tenant
{
    public sealed class AppointmentService
    {
        public Guid AppointmentFK { get; set; }
        public Appointment Appointment { get; set; }
        public Guid SerivceFK { get; set; }
        public Service Service { get; set; }
    }
}
