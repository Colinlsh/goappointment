using Appointment.Infrastructure.Contracts;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Security
{
    public class HttpClientService : IHttpClientService
    {
        #region Private Member
        private readonly HttpClient _httpClient;
        private string _baseUrl;
        #endregion

        #region Public Properties
        public string BaseUrl
        {
            get { return _baseUrl; }
            set
            {
                _baseUrl = value;
                _httpClient.BaseAddress = new Uri(BaseUrl);
            }
        }
        #endregion

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetHttpAsync(string url, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(BaseUrl))
                throw new Exception("BaseURL cannot be empty or null");

            return await _httpClient.GetAsync(url, cancellationToken);
        }
    }
}
