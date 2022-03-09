using System;

namespace Appointment.Domain.Main
{
    public class TenantConfiguration
    {
        public Guid TenantConfigurationID { get; set; }
        public Guid TenantMappingFK { get; set; }
        public string KioskTenantCode { get; set; }
        public string KioskTenantName { get; set; }

        public virtual TenantMapping TenantMapping { get; set; }
    }
}
