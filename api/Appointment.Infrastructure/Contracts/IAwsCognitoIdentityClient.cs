using Amazon.CognitoIdentityProvider;

namespace Appointment.Infrastructure.Contracts
{
    public interface IAwsCognitoIdentityClient
    {
        AmazonCognitoIdentityProviderClient Client { get; }
    }
}