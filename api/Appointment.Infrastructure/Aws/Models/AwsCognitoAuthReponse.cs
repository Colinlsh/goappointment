namespace Appointment.Infrastructure.Aws.Models
{
    public class AwsCognitoAuthReponse
    {
        public string IdToken { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Type { get; set; }
        public int ExpiresIn { get; set; }
    }
}
