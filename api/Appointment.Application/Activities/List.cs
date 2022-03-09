using AutoMapper;
using AutoMapper.QueryableExtensions;
using Appointment.Application.Core;
using Appointment.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;

namespace Appointment.Application.Activities
{
    public class List
    {

        public class Query : IRequest<Result<IList<ActivityDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<IList<ActivityDto>>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppointmentDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<IList<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                // to get all inside a query
                //var activities = await _context.Activities
                //    .Include(a => a.Attendees)
                //    .ThenInclude(u => u.AppUser)
                //    .ToListAsync(cancellationToken);

                // will only query needed fields
                var activities = await _context.Activity
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (activities != null)
                    return Result<IList<ActivityDto>>.Success(activities);

                return Result<IList<ActivityDto>>.Failure("No activities");
            }
        }
    }
}
