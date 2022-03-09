using System.Collections.Generic;

namespace Appointment.Infrastructure.Contracts
{ 
    public interface IClaimManager
    {
        public List<string> GetClaimValues(string key);

        public string GetClaimValue(string key, string @default = default);
    }
}
