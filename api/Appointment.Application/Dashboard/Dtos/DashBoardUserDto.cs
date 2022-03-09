using Appointment.Infrastructure.Dtos.Api;
using System;
using System.Collections.Generic;

namespace Appointment.Application.Dashboard.Dtos
{
    public sealed class DashBoardUserDto
    {
        public Guid AppUserId { get; set; }
        public ICollection<TenantMappingDto> TenantMappings { get; set; }
        public ICollection<AppUserRoleDto> Roles { get; set; }
        public string Token { get; set; }
    }
}
