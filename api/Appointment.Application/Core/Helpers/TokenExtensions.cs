using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Appointment.Application.Core.Helpers
{
    public static class TokenExtensions
    {
        public static async Task SetRefreshToken(this Domain.Tenant.AppUser appUser, IHttpContextService httpContextService)
        {
            // var refreshToken = tokenService.GenerateRefreshToken();

            // appUser.RefreshTokens.Add(refreshToken);
            // await userManager.UpdateAsync(appUser);

            // httpContextService.SetRefreshToken(refreshToken.Token);
        }
    }
}
