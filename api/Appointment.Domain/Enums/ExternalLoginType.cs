using System.ComponentModel;

namespace Appointment.Domain.Enums
{
    public enum ExternalLoginType
    {
        [Description("Facebook")]
        Facebook,
        [Description("Google")]
        Google
    }
}
