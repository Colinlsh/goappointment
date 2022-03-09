using System;

namespace Appointment.Application.Core.Helpers
{
    public static class TenantSettings
    {
        public static T GetValue<T>(string value) where T : IConvertible
        {
            if (typeof(T) == typeof(bool))
            {
                if (bool.TryParse(value, out bool boolResult))
                {
                    return (T)Convert.ChangeType(boolResult, typeof(T));
                }
            }

            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(value, out int intResult))
                {
                    return (T)Convert.ChangeType(intResult, typeof(T));
                }
            }

            return default;
        }
    }
}
