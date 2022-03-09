using Appointment.Infrastructure.Dtos.Api;
using Google.Apis.Auth;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Core.Interfaces
{
    public interface IVerifyExternalLoginService
    {
        public Task<GoogleJsonWebSignature.Payload> VerifyGoogleLoginAsync(string idToken, CancellationToken cancellationToken);
        public Task<FacebookUserInfoDto> VerifyFacebookLoginAsync(string accessToken, string verifyingKey, CancellationToken cancellationToken);
    }
}
