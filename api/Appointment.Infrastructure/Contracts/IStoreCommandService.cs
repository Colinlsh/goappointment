using Appointment.Infrastructure.Dtos.Api;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Core.Interfaces
{
    public interface IStoreCommandService
    {
        Task<bool> CreateStoreAsync(Guid CreateBy, StoreDto storeDto, CancellationToken cancellationToken);
        Task<bool> CreateStoreOffDaysAsync(Guid CreateBy, StoreOffDaysDto storeOffDaysDto, Guid storeId, CancellationToken cancellationToken);
        Task<bool> CreateStoreOffDaysCollectionAsync(Guid CreateBy, ICollection<StoreOffDaysDto> storeOffDaysDtos, Guid storeId, CancellationToken cancellationToken);
        Task<bool> CreateStoreSpecialOffsAsync(Guid CreateBy, StoreSpecialOffsDto storeSpecialOffsDto, Guid storeId, CancellationToken cancellationToken);
        Task<bool> CreateStoreSpecialOffsCollectionAsync(Guid CreateBy, ICollection<StoreSpecialOffsDto> storeSpecialOffsDtos, Guid storeId, CancellationToken cancellationToken);
    }
}