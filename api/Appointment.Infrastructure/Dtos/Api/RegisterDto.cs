using System.Collections.Generic;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class RegisterDto
    {
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public string Birthdate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public ICollection<AppUserRoleDto> AppUserRoleDtos { get; set; }
    }
}
