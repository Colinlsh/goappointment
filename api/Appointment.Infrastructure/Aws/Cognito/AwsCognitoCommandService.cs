using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Appointment.Infrastructure.Aws.Models;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Aws;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Aws.Cognito
{
    public class AwsCognitoCommandService : IAwsCognitoCommandService
    {
        private readonly IOptions<AwsConfiguration> awsConfigurationOptions;
        private readonly IAwsCognitoIdentityClient awsCognitoIdentityClient;

        public AwsCognitoCommandService(IOptions<AwsConfiguration> awsConfigurationOptions, IAwsCognitoIdentityClient awsCognitoIdentityClient)
        {
            this.awsConfigurationOptions = awsConfigurationOptions;
            this.awsCognitoIdentityClient = awsCognitoIdentityClient;
        }

        public async Task<AdminInitiateAuthResponse> SignInAsync(SigninDto signinDto, CancellationToken cancellationToken)
        {
            var _request = new AdminInitiateAuthRequest
            {
                UserPoolId = awsConfigurationOptions.Value.UserPoolId,
                ClientId = awsConfigurationOptions.Value.ClientId,
                AuthFlow = AuthFlowType.ADMIN_USER_PASSWORD_AUTH
            };

            _request.AuthParameters.Add("USERNAME", signinDto.Username);
            _request.AuthParameters.Add("PASSWORD", signinDto.Password);

            return await awsCognitoIdentityClient.Client.AdminInitiateAuthAsync(_request, cancellationToken);
        }
    }
}
