using System;

namespace Appointment.Domain.Tenant
{
    public class StoreSpecialOffs : BaseProperties
    {
        public Guid Id { get; set; }
        public Guid StoreFK { get; set; }
        public Store Store { get; set; }
        public string Description { get; set; }
        public DateTime OffDateTime { get; set; }
        public int OffStartHour { get; set; }
        public int OffStartMinutes { get; set; }
        public int OffEndHour { get; set; }
        public int OffEndMinutes { get; set; }
        public bool IsDaily { get; set; }
    }
}
