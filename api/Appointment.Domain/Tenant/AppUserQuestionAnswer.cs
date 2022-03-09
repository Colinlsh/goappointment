using System;

namespace Appointment.Domain.Tenant
{
    public class AppUserQuestionAnswer
    {
        public Guid AppUserProfileFK { get; set; }
        public UserProfile AppUserProfile { get; set; }
        public Guid QuestionFK { get; set; }
        public Question Question { get; set; }
        public Guid? AnswerFK { get; set; }
        public Answer Answer { get; set; }
    }
}
