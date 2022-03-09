using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Contracts
{
    public interface IException
    {
        HttpStatusCode HttpStatusCode { get; }

        Task TransformHttpResponseAsync(HttpContext httpContext);
    }
}
