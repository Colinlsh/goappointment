using AutoMapper;
using AutoMapper.QueryableExtensions;
using Appointment.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Application.UserProfile
{
    public class List
    {
        public class Query : IRequest<Result<ProfileStateDto>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<ProfileStateDto>>
        {
            private readonly AppointmentMainDataContext _mainDataContext;
            private readonly IMapper _mapper;
            private readonly ILogger<List> _logger;

            public Handler(AppointmentMainDataContext mainDataContext, IMapper mapper, ILogger<List> logger)
            {
                _mainDataContext = mainDataContext;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<ProfileStateDto>> Handle(Query request, CancellationToken cancellationToken)
            {

                try
                {
                    var religions = await _mainDataContext.CTReligion
                                .Where(x => DateTime.Now < x.EffectiveEndDate && DateTime.Now > x.EffectiveStartDate)
                                .ProjectTo<ReligionDto>(_mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken);

                    var occupations = await _mainDataContext.CTOccupation
                        .Where(x => DateTime.Now < x.EffectiveEndDate && DateTime.Now > x.EffectiveStartDate)
                        .ProjectTo<OccupationDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    var countries = await _mainDataContext.CTCountry
                       .Where(x => DateTime.Now < x.EffectiveEndDate && DateTime.Now > x.EffectiveStartDate)
                       .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
                       .ToListAsync(cancellationToken);

                    return Result<ProfileStateDto>.Success(
                        new ProfileStateDto
                        {
                            Religions = religions,
                            Countries = countries,
                            Occupations = occupations
                        });
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"Error: {error.Message}");
                    return Result<ProfileStateDto>.Failure($"Error: {error.Message}");
                }
            }
        }

    }
}
