using System.ComponentModel;

namespace Appointment.Domain.Enums
{
    public enum DbSchemaType
    {
        [Description("AppointmentMain")]
        AppointmentMain,
        [Description("Tenant")]
        Tenant,
    }
}
