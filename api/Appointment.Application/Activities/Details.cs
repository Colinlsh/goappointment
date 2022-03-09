using AutoMapper;
using AutoMapper.QueryableExtensions;
using Appointment.Application.Core;
using Appointment.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;

namespace Appointment.Application.Activities
{
    public class Details
    {

        public class Query : IRequest<Result<ActivityDto>>
        {
            public Guid ActivityId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ActivityDto>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppointmentDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var _activity = await _context.Activity
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.ActivityId == request.ActivityId);

                return Result<ActivityDto>.Success(_activity);
            }
        }

    }
}
