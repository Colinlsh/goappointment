using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string ActiveStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public UserProfile UserProfile { get; set; }
        public Guid UserProfileFK { get; set; }
        // public ICollection<ActivityAttendee> Activities { get; set; }
    }

    // public class AppUserRole : IdentityRole<Guid>
    // {
    //     public int SortOrder { get; set; }
    //     public ICollection<AppUserAppUserRole> AppUsers { get; set; }
    // }

    // public class AppUserAppUserRole
    // {
    //     public AppUser AppUser { get; set; }
    //     public Guid AppUserFK { get; set; }
    //     public AppUserRole AppUserRole { get; set; }
    //     public Guid AppUserRoleFK { get; set; }
    // }
}
