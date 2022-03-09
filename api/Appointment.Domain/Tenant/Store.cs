using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public class Store
    {
        public Guid Id { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public int OperatingStartHour { get; set; }
        public int OperatingStartMinutes { get; set; }
        public int OperatingEndHour { get; set; }
        public int OperatingEndMinutes { get; set; }
        public bool IsOpenOnWeekends { get; set; }
        public bool IsOpenOnSaturday { get; set; }
        public bool IsOpenOnSunday { get; set; }
        public int ServiceHoursPerHour { get; set; }
        public ICollection<StoreOffDays> OffDays { get; set; }
        public ICollection<StoreSpecialOffs> SpecialOffDays { get; set; }
    }
}
