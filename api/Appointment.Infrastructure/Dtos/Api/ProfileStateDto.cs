using System.Collections.Generic;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class ProfileStateDto
    {
        public ICollection<ReligionDto> Religions { get; set; }
        public ICollection<CountryDto> Countries { get; set; }
        public ICollection<OccupationDto> Occupations { get; set; }
    }
}
