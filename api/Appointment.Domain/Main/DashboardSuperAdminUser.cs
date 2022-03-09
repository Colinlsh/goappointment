using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Appointment.Domain.Main
{
    public class DashboardSuperAdminUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string ActiveStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
