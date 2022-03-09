using System.ComponentModel;

namespace Appointment.Domain.Enums
{
    public enum AppointmentStatusType
    {
        [Description("DRAFT")]
        DRAFT,
        [Description("SCHEDULED")]
        SCHEDULED,
        [Description("ACTUALISED")]
        ACTUALISED,
        [Description("RESCHEDULED")]
        RESCHEDULED,
        [Description("CANCELLED")]
        CANCELLED
    }
}
