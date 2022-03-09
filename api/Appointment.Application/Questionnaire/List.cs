using AutoMapper;
using AutoMapper.QueryableExtensions;
using Appointment.Application.Core;
using Appointment.Domain.Enums;
using Appointment.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;

namespace Appointment.Application.Questionnaire
{
    public class List
    {
        public class Query : IRequest<Result<IList<QuestionDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<IList<QuestionDto>>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<List> _logger;

            public Handler(AppointmentDataContext context, IMapper mapper, ILogger<List> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<IList<QuestionDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var questionnaires = await _context.Question
                                   .ProjectTo<QuestionDto>(_mapper.ConfigurationProvider)
                                   .ToListAsync(cancellationToken);

                    if (questionnaires != null)
                    {
                        return Result<IList<QuestionDto>>.Success(questionnaires.ToList());
                    }

                    _logger.LogInformation($"No question available");
                    return Result<IList<QuestionDto>>.Failure("No question available");
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"Error: {error.Message}");
                    return Result<IList<QuestionDto>>.Failure($"Error: {error.Message}");
                }
            }
        }

    }
}
