using System;
using System.Collections.Generic;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public ReligionDto Religion { get; set; }
        public CountryDto Country { get; set; }
        public OccupationDto Occupation { get; set; }
        public string Age { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public ICollection<AppUserPhotoDto> Photos { get; set; }
    }
}
