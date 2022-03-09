using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using Google.Apis.Auth;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Security
{
    public class VerifyExternalLoginService : IVerifyExternalLoginService
    {
        private const string FACEBOOK_BASE_URL = "https://graph.facebook.com/v10.0/";
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger<VerifyExternalLoginService> _logger;

        public VerifyExternalLoginService(IHttpClientService httpClientService, ILogger<VerifyExternalLoginService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
        }

        public async Task<FacebookUserInfoDto> VerifyFacebookLoginAsync(string accessToken, string verifyingKey, CancellationToken cancellationToken)
        {
            _httpClientService.BaseUrl = FACEBOOK_BASE_URL;

            var verifyToken = await _httpClientService.GetHttpAsync($"debug_token?input_token={accessToken}&access_token={verifyingKey}", cancellationToken);

            // return fail if cannot verify
            if (!verifyToken.IsSuccessStatusCode) throw new Exception(verifyToken.ReasonPhrase);

            var response = await _httpClientService.GetHttpAsync($"me?access_token={accessToken}&fields=name, email, picture.width(100).height(100)", cancellationToken);

            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);

            _logger.LogInformation("Facebook Verification Success");
            return JsonConvert.DeserializeObject<FacebookUserInfoDto>(await response.Content.ReadAsStringAsync(cancellationToken));
        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleLoginAsync(string idToken, CancellationToken cancellationToken)
        {
            return await GoogleJsonWebSignature.ValidateAsync(idToken, new GoogleJsonWebSignature.ValidationSettings());
        }
    }
}
