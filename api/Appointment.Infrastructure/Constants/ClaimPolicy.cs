using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Infrastructure.Constants
{
    public class ClaimPolicy
    {
        public const string PatientReadAccess = "PatientReadAccess";
        public const string PatientWriteAccess = "PatientWriteAccess";
        public const string PatientVitalThresholdWriteAccess = "VitalThresholdWriteAccess";
        public const string SendSms = "SendSms";
        public const string MarkAttended = "MarkAttended";

        public const string UserAdmin = "UserAdmin";
        public const string User = "User";
        public const string SuperAdmin = "SuperAdmin";

        public const string ViewGroup = "ViewGroup";
        public const string ViewUser = "ViewUser";

        public const string VitalKiosk = "VitalKiosk";
        public const string VitalByod = "VitalByod";
    }
}
