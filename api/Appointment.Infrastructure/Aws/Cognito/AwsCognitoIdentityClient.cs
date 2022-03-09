using Amazon;
using Amazon.CognitoIdentityProvider;
using Appointment.Infrastructure.Contracts;

namespace Appointment.Infrastructure.Aws.Cognito
{
    public class AwsCognitoIdentityClient : IAwsCognitoIdentityClient
    {
        private AmazonCognitoIdentityProviderClient amazonCognitoIdentityProviderClient;

        public AmazonCognitoIdentityProviderClient Client
        {
            get
            {
                if (amazonCognitoIdentityProviderClient != null)
                {
                    return amazonCognitoIdentityProviderClient;
                }

                amazonCognitoIdentityProviderClient = new AmazonCognitoIdentityProviderClient(RegionEndpoint.APSoutheast1);

                return amazonCognitoIdentityProviderClient;
            }
        }

        public AwsCognitoIdentityClient()
        {
            amazonCognitoIdentityProviderClient = new AmazonCognitoIdentityProviderClient(RegionEndpoint.APSoutheast1);
        }
    }
}