using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Appointment.Application.Core;
using Appointment.Domain.Enums;
using Appointment.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Common;

namespace Appointment.Application.Questionnaire
{
    public class AnsweredQuestions
    {

        public class Command : IRequest<Result<IList<QuestionAnswerDto>>>
        {
            public IList<AppUserQuestionAnswerDto> AppUserQuestionAnswers { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<IList<QuestionAnswerDto>>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<AnsweredQuestions> _logger;

            public Handler(AppointmentDataContext context, IMapper mapper, ILogger<AnsweredQuestions> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<IList<QuestionAnswerDto>>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // // find user
                    // var _user = await _userManager.Users
                    //                 .Include(x => x.AppUserProfile)
                    //                 .SingleOrDefaultAsync(x => x.UserName == request.AppUserQuestionAnswers.First().UserName, cancellationToken);

                    // // check if answer exist or not
                    // // sift out open ended, combobox can also have open ended answers
                    // IEnumerable<AppUserQuestionAnswerDto> _openEnded = await ExtractOpenEndedAnswers(request, cancellationToken);

                    // //check if current user has answered the question in db, if answered, remove prevailing one
                    // RemovePrevailingAnswers(request, _user);

                    // var _appUserQuestionAnswers = new List<AppUserQuestionAnswer>();

                    // _appUserQuestionAnswers.AddRange(request.AppUserQuestionAnswers
                    //     .Where(x => x.QuestionType != QuestionType.OpenEnded.GetDescription())
                    //     .Select(x => new AppUserQuestionAnswer { AppUserProfileFK = _user.Id, AnswerFK = x.AnswerId, QuestionFK = x.QuestionId, AppUserProfile = _user.AppUserProfile, Answer = _context.Answer.SingleOrDefault(y => y.AnswerId == x.AnswerId), Question = _context.Question.SingleOrDefault(q => q.QuestionId == x.QuestionId) }).ToList());

                    // _appUserQuestionAnswers.AddRange(_openEnded
                    //      .Select(x => new AppUserQuestionAnswer { AppUserProfileFK = _user.Id, AnswerFK = x.AnswerId, QuestionFK = x.QuestionId, AppUserProfile = _user.AppUserProfile, Answer = _context.Answer.SingleOrDefault(y => y.AnswerId == x.AnswerId), Question = _context.Question.SingleOrDefault(q => q.QuestionId == x.QuestionId) }));

                    // await _context.AppUserQuestionAnswer.AddRangeAsync(_appUserQuestionAnswers, cancellationToken);

                    // var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                    // if (!result)
                    // {
                    //     _logger.LogWarning($"Failed to save answers: No new answers");
                    //     return Result<IList<QuestionAnswerDto>>.Failure($"Failed to save answers: No new answers");
                    // }

                    // // get updated user answered question and return it.
                    // var questionAnswers = await _context.AppUserQuestionAnswer
                    //      .Where(x => x.AppUserProfileFK == _user.Id)
                    //      .ProjectTo<QuestionAnswerDto>(_mapper.ConfigurationProvider)
                    //      .ToListAsync(cancellationToken);

                    // if (questionAnswers != null)
                    //     return Result<IList<QuestionAnswerDto>>.Success(questionAnswers);

                    // _logger.LogWarning($"No answered question available");
                    return Result<IList<QuestionAnswerDto>>.Failure("No answered question available");

                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"Failed to save answers: error: {error.Message}");
                    return Result<IList<QuestionAnswerDto>>.Failure($"Failed to save answers: error: {error.Message}");
                }
            }

            // private void RemovePrevailingAnswers(Command request, Domain.Tenant.AppUser _user)
            // {
            //     var _toRemove = request.AppUserQuestionAnswers
            //         .SelectMany(x => _context.AppUserQuestionAnswer.Where(y => y.AppUserProfileFK == _user.Id && y.QuestionFK == x.QuestionId));

            //     _context.AppUserQuestionAnswer.RemoveRange(_toRemove);
            // }

            // private async Task<IEnumerable<AppUserQuestionAnswerDto>> ExtractOpenEndedAnswers(Command request, CancellationToken cancellationToken)
            // {
            //     var _openEnded = request.AppUserQuestionAnswers
            //         .Where(x => x.QuestionType == QuestionType.OpenEnded.GetDescription() || (x.QuestionType == QuestionType.Combo.GetDescription() && x.AnswerId == null));

            //     var openEndedAnswers = new List<Answer>();

            //     foreach (var answer in _context.Answer)
            //     {
            //         foreach (var openended in _openEnded)
            //         {
            //             if (!openended.OpenEndedAnswer.Equals(answer.DisplayValue, StringComparison.OrdinalIgnoreCase))
            //             {
            //                 // if answer does not exist in current db, add into db
            //                 var _ans = openEndedAnswers.FirstOrDefault(x => x.DisplayValue == openended.OpenEndedAnswer);
            //                 if (_ans != null)
            //                 {
            //                     openended.AnswerId = _ans.AnswerId;
            //                     continue;
            //                 }

            //                 var newAnswer = new Answer
            //                 {
            //                     AnswerId = Guid.NewGuid(),
            //                     DisplayValue = openended.OpenEndedAnswer,
            //                     EffectiveStartDate = DateTime.Now,
            //                     EffectiveEndDate = DateTime.Parse("2999-12-31 00:00:00"),
            //                     CreateDate = DateTime.Now,
            //                     UpdateDate = DateTime.Now,
            //                 };

            //                 openEndedAnswers.Add(newAnswer);

            //                 openended.AnswerId = newAnswer.AnswerId;
            //             }
            //         }
            //     }

            //     await _context.Answer.AddRangeAsync(openEndedAnswers, cancellationToken);
            //     return _openEnded;
            // }
        }

    }
}
