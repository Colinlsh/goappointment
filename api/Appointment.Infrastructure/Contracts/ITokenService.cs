using Appointment.Domain.Tenant;
using Microsoft.AspNetCore.Identity;
using System;

namespace Appointment.Application.Core.Interfaces
{ 
    public interface ITokenService
    {
        string CreateToken<T>(T user) where T : IdentityUser<Guid>;
        RefreshToken GenerateRefreshToken();
    }
}