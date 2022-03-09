using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public class TelegramCustomerProfile
    {
        public Guid TelegramCustomerProfileId { get; set; }
        public long ChatId { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }

        public ICollection<AppointmentTelegramCustomerProfile> Appointments { get; set; }
    }
}
