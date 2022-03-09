using Appointment.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Appointment.Infrastructure.Security
{
    public class ClaimManager : IClaimManager
    {
        private readonly HttpContext httpContext;
        private readonly ILogger<ClaimManager> _logger;


        public ClaimManager(ILogger<ClaimManager> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            httpContext = httpContextAccessor.HttpContext;
        }

        public string GetClaimValue(string key, string @default = null)
        {
            var values = GetClaimValues(key);

            return values.FirstOrDefault() ?? @default;
        }

        public List<string> GetClaimValues(string key)
        {
            return httpContext?.User?.Claims.Where(x => string.Compare(x.Type, key, true) == 0).Select(x => x.Value).ToList() ?? new List<string>();
        }
    }
}
