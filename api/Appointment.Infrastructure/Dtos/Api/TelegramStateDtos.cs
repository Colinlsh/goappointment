using System;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class TelegramStateDto
    {
        public bool IsStoreSelected { get; set; } = false;
        public bool IsBookingTimeConfirmed { get; set; } = false;
        public string SelectedTenantHeCode { get; set; }
        public DateTime? DesiredBookingDate { get; set; } = null;
        public DateTime? BookedDate { get; set; } = null;
    }
}
