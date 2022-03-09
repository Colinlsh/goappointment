namespace Appointment.Domain.Tenant
{
    public class TenantSettings : BaseProperties
    {
        public string TenantSettingID { get; set; }
        public string Value { get; set; }
        public bool IsUserMaintainable { get; set; }
    }
}
