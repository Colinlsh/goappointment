using System;

namespace Appointment.Domain.Tenant
{
    public class ActivityAttendee
    {
        public Guid AppUserFK { get; set; }
        public AppUser AppUser { get; set; }
        public Guid ActivityFK { get; set; }
        public Activity Activity { get; set; }
        public bool IsHost { get; set; }
    }
}
