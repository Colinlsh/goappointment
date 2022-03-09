using System.ComponentModel;

namespace Appointment.Domain.Enums
{
    public enum ActiveStatus
    {
        [Description("A")]
        Active,
        [Description("I")]
        InActive,
        [Description("D")]
        Deleted
    }
}
