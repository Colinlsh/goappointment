using Appointment.Domain.Enums;
using System;

namespace Appointment.Application.Questionnaire
{
    public class AppUserQuestionAnswerDto
    {
        public string UserName { get; set; }
        public Guid? AnswerId { get; set; }
        public Guid QuestionId { get; set; }
        public string OpenEndedAnswer { get; set; }
        public string QuestionType { get; set; }
    }
}
