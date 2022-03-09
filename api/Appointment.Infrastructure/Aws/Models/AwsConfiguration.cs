namespace Appointment.Infrastructure.Aws.Models
{
    public class AwsConfiguration
    {
        public string Profile { get; set; }
        public string Region { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string UserPoolId { get; set; }
        public string ClientId { get; set; }
        public AwsCognitoConfiguration CognitoConfiguration { get; set; }
    }
}
