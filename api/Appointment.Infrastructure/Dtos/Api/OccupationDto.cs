using System;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class OccupationDto
    {
        public Guid OccupationId { get; set; }
        public string DisplayValue { get; set; }
        public string Description { get; set; }
    }
}
