namespace Appointment.Infrastructure.Contracts
{
    public interface IHttpContextService
    {
        string GetHeCode();
        string GetUsername();
        string GetRefreshToken();
        void SetRefreshToken(string refreshToken);
        string GetRequestHeaders(string header);
    }
}
