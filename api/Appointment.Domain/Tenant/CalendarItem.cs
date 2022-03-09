using System;

namespace Appointment.Domain.Tenant
{
    public class CalendarItem : BaseProperties
    {
        public Guid Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int DurationHour { get; set; }
        public int DurationMinutes { get; set; }
        public Appointment Appointment { get; set; }
    }
}
