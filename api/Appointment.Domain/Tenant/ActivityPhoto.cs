using System;

namespace Appointment.Domain.Tenant
{
    public sealed class ActivityPhoto
    {
        public string PhotoId { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public Activity Activity { get; set; }
        public Guid ActivityFk { get; set; }
    }
}
