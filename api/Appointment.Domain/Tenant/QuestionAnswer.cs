using System;

namespace Appointment.Domain.Tenant
{
    public class QuestionAnswer
    {
        public Guid QuestionFk { get; set; }
        public Question Question { get; set; }
        public Guid AnswerFk { get; set; }
        public Answer Answer { get; set; }
    }
}
