using Amazon.CognitoIdentityProvider.Model;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Infrastructure.Dtos.Aws;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Contracts
{
    public interface IAwsCognitoCommandService
    {
        Task<AdminInitiateAuthResponse> SignInAsync(SigninDto signinDto, CancellationToken cancellationToken);
    }
}