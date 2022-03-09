namespace Appointment.Infrastructure.Dtos.Api
{
    public class EditUserDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public ReligionDto Religion { get; set; }
        public CountryDto Country { get; set; }
        public OccupationDto Occupation { get; set; }
    }
}
