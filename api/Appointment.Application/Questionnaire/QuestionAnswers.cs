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
using Appointment.Infrastructure.Common;

namespace Appointment.Application.Questionnaire
{
    public class QuestionAnswers
    {

        public class Query : IRequest<Result<IList<QuestionAnswerDto>>>
        {
            public Guid AppUserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<IList<QuestionAnswerDto>>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<QuestionAnswers> _logger;

            public Handler(AppointmentDataContext context, IMapper mapper, ILogger<QuestionAnswers> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<IList<QuestionAnswerDto>>> Handle(Query request, CancellationToken cancellationToken)
            {

                try
                {
                    var questionAnswers = await _context.AppUserQuestionAnswer
                        .Where(x => x.AppUserProfileFK == request.AppUserId)
                        .ProjectTo<QuestionAnswerDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    if (questionAnswers != null)
                        return Result<IList<QuestionAnswerDto>>.Success(questionAnswers);

                    return Result<IList<QuestionAnswerDto>>.Failure("No answered question available");
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"Error: {error.Message}");
                    return Result<IList<QuestionAnswerDto>>.Failure($"Error: {error.Message}");
                }
            }
        }

    }
}
