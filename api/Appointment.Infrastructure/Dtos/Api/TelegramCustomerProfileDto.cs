using System;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class TelegramCustomerProfileDto
    {
        public Guid TelegramCustomerProfileId { get; set; }
        public long ChatId { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
    }
}
