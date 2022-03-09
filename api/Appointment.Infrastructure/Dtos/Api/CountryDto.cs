using System;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class CountryDto
    {
        public Guid CountryId { get; set; }
        public string Code { get; set; }
        public string DisplayValue { get; set; }
    }
}
