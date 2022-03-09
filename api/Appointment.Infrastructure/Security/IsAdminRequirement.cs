using Amazon.CognitoIdentityProvider.Model;
using Appointment.Infrastructure.Aws.Models;
using Appointment.Infrastructure.Constants;
using Appointment.Infrastructure.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Security
{
    public class IsAdminRequirement : IAuthorizationRequirement
    {
    }

    public class IsAdminRequirementHandler : AuthorizationHandler<IsAdminRequirement>
    {
        private readonly IHttpContextService httpContextservice;
        private readonly IAwsCognitoIdentityClient awsCognitoIdentityClient;
        private readonly IOptions<AwsConfiguration> awsConfigurationOptions;

        public IsAdminRequirementHandler(IHttpContextService httpContextservice, IAwsCognitoIdentityClient awsCognitoIdentityClient, IOptions<AwsConfiguration> awsConfigurationOptions)
        {
            this.httpContextservice = httpContextservice;
            this.awsCognitoIdentityClient = awsCognitoIdentityClient;
            this.awsConfigurationOptions = awsConfigurationOptions;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            var request = new AdminListGroupsForUserRequest
            {
                UserPoolId = awsConfigurationOptions.Value.UserPoolId,
                Username = httpContextservice.GetRequestHeaders("username"),
                Limit = 5
            };

            var result = await awsCognitoIdentityClient.Client.AdminListGroupsForUserAsync(request);

            if (!result.Groups.Any())
                context.Fail();
            else
            {
                var g = result.Groups.FirstOrDefault(x => x.GroupName.Equals(SpecialAuthorization.Admin, System.StringComparison.OrdinalIgnoreCase));

                if (g is not null)
                    context.Succeed(requirement);
                else
                    context.Fail();
            }

            await Task.CompletedTask;
        }
    }

}
