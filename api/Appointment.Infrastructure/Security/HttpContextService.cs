using Appointment.Infrastructure.Constants;
using Appointment.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Appointment.Infrastructure.Security
{
    public class HttpContextService : IHttpContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextService(IHttpContextAccessor httpContextAccesor)
        {
            _httpContextAccessor = httpContextAccesor
                ?? throw new ArgumentNullException(nameof(httpContextAccesor));
        }

        public string GetHeCode()
        {
            if (_httpContextAccessor.HttpContext is null)
                return "InvalidHeCode";

            var isHeCodeAvailable = _httpContextAccessor.HttpContext.Request.Headers
                .TryGetValue(RequestHeaderConstants.HeCode, out var heCode);

            return isHeCodeAvailable ? heCode : "InvalidHeCode";
        }

        public string GetUsername()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }

        public string GetRefreshToken()
        {
            var isRefreshTokenAvailable = _httpContextAccessor.HttpContext.Request.Cookies
                .TryGetValue(RequestHeaderConstants.RefreshToken, out var refreshToken);

            return isRefreshTokenAvailable ? refreshToken : "";
        }

        public void SetRefreshToken(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append(RequestHeaderConstants.RefreshToken, refreshToken, cookieOptions);
        }

        public string GetRequestHeaders(string header)
        {
            return _httpContextAccessor.HttpContext.Request.Headers[header];
        }
    }
}
