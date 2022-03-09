using System.ComponentModel;

namespace Appointment.Domain.Enums
{
    public enum QuestionType
    {
        [Description("MCQ")]
        MCQ,
        [Description("OPEN")]
        OpenEnded,
        [Description("COMBO")]
        Combo,
    }
}
