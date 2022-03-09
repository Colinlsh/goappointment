using AutoMapper;
using Appointment.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Appointment.Persistence.Extentions;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Application.UserProfile.Religion
{
    public class List
    {
        public class Query : IRequest<Result<IList<ReligionDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<IList<ReligionDto>>>
        {
            private readonly AppointmentMainDataContext _mainContext;
            private readonly IMapper _mapper;
            private readonly ILogger<List> _logger;
            private readonly IMemoryCache _memoryCache;

            public Handler(AppointmentMainDataContext mainContext, IMapper mapper, ILogger<List> logger, IMemoryCache memoryCache)
            {
                _mainContext = mainContext;
                _mapper = mapper;
                _logger = logger;
                _memoryCache = memoryCache;
            }

            public async Task<Result<IList<ReligionDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var religions = _mainContext.CTReligion.GetFromCache(_memoryCache)
                     .Where(x => DateTime.Now < x.EffectiveEndDate && DateTime.Now > x.EffectiveStartDate)
                     .OrderBy(x => x.SortOrder);

                    var religionDtos = _mapper.Map<IList<ReligionDto>>(religions);

                    return Result<IList<ReligionDto>>.Success(religionDtos);
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"Error: {error.Message}");
                    return Result<IList<ReligionDto>>.Failure($"Error: {error.Message}");
                }
            }
        }
    }
}
