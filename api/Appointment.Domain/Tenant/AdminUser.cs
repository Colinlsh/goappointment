using System;

namespace Appointment.Domain.Tenant
{
    public class AdminUser : BaseProperties
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string ActiveStatus { get; set; }
        public Guid UserProfileFK { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}