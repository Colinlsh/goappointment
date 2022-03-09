using System;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class ReligionDto
    {
        public Guid Id { get; set; }
        public string DisplayValue { get; set; }
        public string Code { get; set; }
    }
}
