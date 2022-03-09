using System;
using System.Collections.Generic;

namespace Appointment.Infrastructure.Dtos.Api
{
    public sealed class ServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<ServiceItemDto> ServiceItemDtos { get; set; }
    }
}
