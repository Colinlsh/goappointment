using System;
using System.Collections.Generic;

namespace Appointment.Infrastructure.Dtos.Api
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime BookDate { get; set; }
        public string AppointmentStatus { get; set; }
        public ICollection<TelegramCustomerProfileDto> TelegramCustomerProfile { get; set; }
        public ICollection<CustomerProfileDto> CustomerProfileDtos { get; set; }
        public ICollection<ServiceDto> ServiceDtos { get; set; }
    }
}
