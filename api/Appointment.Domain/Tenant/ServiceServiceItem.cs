using System;

namespace Appointment.Domain.Tenant
{
    public sealed class ServiceServiceItem
    {
        public Guid ServiceFK { get; set; }
        public Service Service { get; set; }
        public Guid ServiceItemFK { get; set; }
        public ServiceItem ServiceItem { get; set; }
    }
}
