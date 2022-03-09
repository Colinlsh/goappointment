using System;

namespace Appointment.Domain.Main
{
    public class RefreshToken
    {
        public Guid RefreshTokenId { get; set; }
        // public DashboardSuperAdminUser SuperAdminUser { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; } = DateTime.Now.AddDays(7);
        public bool IsExpired => DateTime.Now >= Expires;
        public DateTime? Revoked { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
