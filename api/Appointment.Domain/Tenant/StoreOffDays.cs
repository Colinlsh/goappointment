using System;

namespace Appointment.Domain.Tenant
{
    public class StoreOffDays : BaseProperties
    {
        public Guid Id { get; set; }
        public Guid StoreFK { get; set; }
        public Store Store { get; set; }
        public string Description { get; set; }
        public DateTime OffDay { get; set; }
    }
}
