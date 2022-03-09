using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public class CustomerProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<AppointmentCustomerProfile> Appointments { get; set; }
    }
}
