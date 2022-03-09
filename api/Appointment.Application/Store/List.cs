using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Store
{
    public class List
    {
        public class Query : IRequest<Result<IList<StoreDto>>>
        {
            public string HeCode { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<IList<StoreDto>>>
        {
            private readonly IStoreRequestService _storeRequestService;

            public Handler(IStoreRequestService storeRequestService)
            {
                _storeRequestService = storeRequestService;
            }

            public async Task<Result<IList<StoreDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var storedtos = await _storeRequestService.GetStoresAsync(cancellationToken);

                    if (storedtos != null)
                        return Result<IList<StoreDto>>.Success(storedtos);

                    return Result<IList<StoreDto>>.Failure("No stores found");
                }
                catch (Exception ex)
                {
                    return Result<IList<StoreDto>>.Failure(ex.Message);
                }
            }
        }

    }
}
