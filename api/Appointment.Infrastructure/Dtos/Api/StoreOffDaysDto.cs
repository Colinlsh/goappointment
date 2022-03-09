using System;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class StoreOffDaysDto
    {
        public Guid Id { get; set; }
        public DateTime OffDay { get; set; }
        public string Description { get; set; }
    }
}
