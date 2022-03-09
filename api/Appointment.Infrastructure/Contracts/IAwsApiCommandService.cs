using System.Threading;
using System.Threading.Tasks;
using Amazon.CognitoIdentityProvider.Model;
using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Infrastructure.Contracts
{
    public interface IAwsApiCommandService
    {
        Task<AdminCreateUserResponse> CreateAdminUserAsync(CreateAdminUserDto createAdminUserDto, CancellationToken cancellationToken);
    }
}