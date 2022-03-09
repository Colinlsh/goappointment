using System;

namespace Appointment.Application.Questionnaire
{
    public class AnswerQuestionDto
    {
        public Guid QuestionId { get; set; }
        public Guid SelectedAnswer { get; set; }
    }
}
