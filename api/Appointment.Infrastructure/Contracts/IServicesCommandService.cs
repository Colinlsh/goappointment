using Appointment.Infrastructure.Dtos.Api;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Contracts
{
    public interface IServicesCommandService
    {
        Task<bool> EditService(ServiceDto serviceDto, CancellationToken cancellationToken);
    }
}