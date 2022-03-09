using AutoMapper;
using AutoMapper.QueryableExtensions;
using Appointment.Application.Core;
using Appointment.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Infrastructure.Common;

namespace Appointment.Application.UserProfile.Occupation
{
    public class List
    {

        public class Query : IRequest<Result<IList<OccupationDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<IList<OccupationDto>>>
        {
            private readonly AppointmentMainDataContext _mainContext;
            private readonly IMapper _mapper;
            private readonly ILogger<List> _logger;

            public Handler(AppointmentMainDataContext mainContext, IMapper mapper, ILogger<List> logger)
            {
                _mainContext = mainContext;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<IList<OccupationDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var occupation = await _mainContext.CTOccupation
                    .Where(x => DateTime.Now < x.EffectiveEndDate && DateTime.Now > x.EffectiveStartDate)
                    .OrderBy(x => x.DisplayValue)
                    .ProjectTo<OccupationDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                    return Result<IList<OccupationDto>>.Success(occupation);
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"Error: {error.Message}");
                    return Result<IList<OccupationDto>>.Failure($"Error: {error.Message}");
                }
            }
        }

    }
}
