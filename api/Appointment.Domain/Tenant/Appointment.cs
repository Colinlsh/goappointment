using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid AppointmentStatusFK { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public Guid CalendarItemFK { get; set; }
        public CalendarItem CalendarItem { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid VisitFK { get; set; }
        public bool IsCancelled { get; set; } = false;
        public DateTime CancellationDateTime { get; set; }
        public Guid CancellationRequestBy { get; set; }
        public string CancellationReason { get; set; }
        public bool IsRemainderSent { get; set; }
        public bool IsReScheduled { get; set; }
        public bool IsCustomerTurnUp { get; set; }
        public bool IsTelegram { get; set; }
        public DateTime BookDate { get; set; }
        public ICollection<AppointmentTelegramCustomerProfile> TelegramCustomerProfile { get; set; }
        public ICollection<AppointmentCustomerProfile> CustomerProfiles { get; set; }
        public ICollection<AppointmentService> Services { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
