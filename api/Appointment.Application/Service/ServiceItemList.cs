using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Service
{
    public class ServiceItemList
    {
        public class Query : IRequest<Result<IList<ServiceItemDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<IList<ServiceItemDto>>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppointmentDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<IList<ServiceItemDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var serviceItemDtos = await _context.ServiceItem
                                            .OrderBy(si => si.SortOrder)
                                            .ProjectTo<ServiceItemDto>(_mapper.ConfigurationProvider)
                                            .ToListAsync(cancellationToken);

                if (serviceItemDtos == null) return Result<IList<ServiceItemDto>>.Failure("No service items");
                return Result<IList<ServiceItemDto>>.Success(serviceItemDtos);
            }
        }

    }
}
