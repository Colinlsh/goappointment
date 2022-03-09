using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Contracts
{
    public interface IHttpClientService
    {
        string BaseUrl { get; set; }

        Task<HttpResponseMessage> GetHttpAsync(string url, CancellationToken cancellationToken);
    }
}
