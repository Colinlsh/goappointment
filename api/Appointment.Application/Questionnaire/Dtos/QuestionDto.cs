using System;
using System.Collections.Generic;

namespace Appointment.Application.Questionnaire
{
    public class QuestionDto
    {
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public ICollection<AnswerDto> Answers{ get; set; }
        public string Type { get; set; }
    }
}
