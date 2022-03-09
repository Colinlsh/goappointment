using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Infrastructure.Contracts
{
    public interface IAdminUserCommandService
    {
        Task<bool> CreateAdminUserAsync(CreateAdminUserDto createAdminUserDto, CancellationToken cancellationToken);
    }
}
