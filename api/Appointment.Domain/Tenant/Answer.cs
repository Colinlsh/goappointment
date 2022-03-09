using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public class Answer
    {
        public Guid AnswerId { get; set; }
        public string DisplayValue { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<AppUserQuestionAnswer> AppUserQuestions { get; set; }
        public ICollection<QuestionAnswer> Questions { get; set; }
    }
}
