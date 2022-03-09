using AutoMapper;
using Appointment.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Persistence.Extentions;
using Microsoft.Extensions.Caching.Memory;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Infrastructure.Common;

namespace Appointment.Application.UserProfile.Country
{
    public class List
    {

        public class Query : IRequest<Result<IList<CountryDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<IList<CountryDto>>>
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

            public async Task<Result<IList<CountryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var countries = _mainContext.CTCountry.GetFromCache(_memoryCache)
                                   .Where(x => DateTime.Now < x.EffectiveEndDate && DateTime.Now > x.EffectiveStartDate)
                                   .OrderBy(x => x.SortOrder);

                    var countriesDto = _mapper.Map<IList<CountryDto>>(countries);

                    return Result<IList<CountryDto>>.Success(countriesDto);
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"Error: {error.Message}");
                    return Result<IList<CountryDto>>.Failure($"Error: {error.Message}");
                }
            }
        }

    }
}
