using Appointment.Infrastructure.Dtos.Api;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Core.Interfaces
{
    public interface IStoreRequestService
    {
        Task<StoreDto> GetStoreAsync(CancellationToken cancellationToken);
        Task<IList<StoreDto>> GetStoresAsync(CancellationToken cancellationToken);
    }
}