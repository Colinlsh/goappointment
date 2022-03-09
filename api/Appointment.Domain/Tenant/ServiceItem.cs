using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public sealed class ServiceItem : BaseProperties
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationHour { get; set; }
        public int DurationMinutes { get; set; }
        public ICollection<ServiceServiceItem> Services { get; set; }
    }
}
