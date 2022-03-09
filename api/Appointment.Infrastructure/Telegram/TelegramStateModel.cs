using Appointment.Domain.Main;

namespace Appointment.Infrastructure.Telegram
{
    public class TelegramStateModel
    {
        public bool IsStoreSelected { get; set; } = false;
        public bool IsBookingTimeConfirmed { get; set; } = false;
        public string SelectedTenantHeCode { get; set; }
    }
}
