using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Application.Dashboard.Dtos
{
    public class DashboardRegisterDto
    {
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public AppUserRoleDto Role { get; set; }
    }
}
