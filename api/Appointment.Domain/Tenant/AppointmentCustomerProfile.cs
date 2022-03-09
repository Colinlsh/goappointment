using System;

namespace Appointment.Domain.Tenant
{
    public class AppointmentCustomerProfile
    {
        public Guid AppointmentFK { get; set; }
        public Appointment Appointment { get; set; }
        public Guid CustomerProfileFK { get; set; }
        public CustomerProfile CustomerProfile { get; set; }
    }
}
