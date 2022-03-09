using System;

namespace Appointment.Infrastructure.Dtos.Api
{
    public sealed class ServiceItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationHour { get; set; }
        public int DurationMinutes { get; set; }
    }
}
