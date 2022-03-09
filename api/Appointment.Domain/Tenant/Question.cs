using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public string DisplayValue { get; set; }
        public bool IsUserMaintainable { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Type { get; set; }
        public ICollection<AppUserQuestionAnswer> AppUserAnswers { get; set; }
        public ICollection<QuestionAnswer> Answers { get; set; }
    }
}
