using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Store
{
    public class Details
    {
        public class Query : IRequest<Result<StoreDto>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<StoreDto>>
        {
            private readonly IStoreRequestService _storeRequestService;

            public Handler(IStoreRequestService storeRequestService)
            {
                _storeRequestService = storeRequestService;
            }

            public async Task<Result<StoreDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var storedto = await _storeRequestService.GetStoreAsync(cancellationToken);

                    if (storedto != null)
                        return Result<StoreDto>.Success(storedto);

                    return Result<StoreDto>.Failure("No store found");
                }
                catch (Exception ex)
                {
                    return Result<StoreDto>.Failure(ex.Message);
                }
            }
        }

    }
}
