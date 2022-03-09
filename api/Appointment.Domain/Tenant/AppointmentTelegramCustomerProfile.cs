using System;

namespace Appointment.Domain.Tenant
{
    public class AppointmentTelegramCustomerProfile
    {
        public Appointment Appointment { get; set; }
        public Guid AppointmentFK { get; set; }
        public TelegramCustomerProfile TelegramCustomerProfile { get; set; }
        public Guid TelegramCustomerProfileFK { get; set; }
    }
}
