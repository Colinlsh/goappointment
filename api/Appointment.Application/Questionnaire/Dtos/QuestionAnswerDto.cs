using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Questionnaire
{
    public class QuestionAnswerDto
    {
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public Guid AnswerId { get; set; }
        public string Answer { get; set; }
    }
}
