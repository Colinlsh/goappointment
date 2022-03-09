using System;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class StoreSpecialOffsDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime OffDateTime { get; set; }
        public int OffStartHour { get; set; }
        public int OffStartMinutes { get; set; }
        public int OffEndHour { get; set; }
        public int OffEndMinutes { get; set; }
        public bool IsDaily { get; set; }
    }
}
