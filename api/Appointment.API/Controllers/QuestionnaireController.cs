using Appointment.Application.Questionnaire;
using Appointment.Infrastructure.Controller;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.API.Controllers
{
    public class QuestionnaireController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("userquestionanswers/{id}")]
        public async Task<IActionResult> GetUserQuestionAnswers(Guid id)
        {
            return HandleResult(await Mediator.Send(new QuestionAnswers.Query { AppUserId = id }));
        }

        [HttpPost("submitansweredquestions")]
        public async Task<IActionResult> SubmitAnsweredQuestions(IList<AppUserQuestionAnswerDto> appUserQuestionAnswers)
        {
            return HandleResult(await Mediator.Send(new AnsweredQuestions.Command { AppUserQuestionAnswers = appUserQuestionAnswers }));

        }
    }
}
