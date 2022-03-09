using System;

namespace Appointment.Domain.Main
{
    public class TenantMapping
    {
        public Guid TenantID { get; set; }
        public string TenantCode { get; set; }
        public string SchemaName { get; set; }
        public string DBServer { get; set; }
        public string DBName { get; set; }
        public string DBUsername { get; set; }
        public string DBUserPassword { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public int TenantIndex { get; set; }
        public string HeCode { get; set; }
        public bool? IsMobileEnabled { get; set; }

        public TenantConfiguration TenantConfiguration { get; set; }
    }
}
