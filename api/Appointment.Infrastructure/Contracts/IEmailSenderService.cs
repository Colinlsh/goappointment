using System.Threading.Tasks;

namespace Appointment.Infrastructure.Contracts
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string userEmail, string emailSubject, string msg);
    }
}