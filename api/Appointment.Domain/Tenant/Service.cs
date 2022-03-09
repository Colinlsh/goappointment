using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public sealed class Service : BaseProperties
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<ServiceServiceItem> ServiceItems { get; set; }
        public ICollection<AppointmentService> Appointments { get; set; }
    }
}
