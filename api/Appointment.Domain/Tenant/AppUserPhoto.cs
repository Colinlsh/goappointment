using System;

namespace Appointment.Domain.Tenant
{
    public class AppUserPhoto
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public UserProfile AppUserProfile { get; set; }
        public Guid AppUserProfileFK { get; set; }
    }
}
