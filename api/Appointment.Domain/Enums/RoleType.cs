using System.ComponentModel;

namespace Appointment.Domain.Enums
{
    public enum RoleType
    {
        [Description("SuperAdmin")]
        SuperAdmin,
        [Description("TenantOwner")]
        TenantOwner,
        [Description("Customer")]
        Customer
    }
}
