using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.CognitoIdentityProvider.Model;
using Appointment.Infrastructure.Aws.Models;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Appointment.Infrastructure.Aws.Api
{
    public class AwsApiCommandService : IAwsApiCommandService
    {
        private readonly IOptions<AwsConfiguration> awsConfigurationOptions;
        private readonly IAwsCognitoIdentityClient awsCognitoIdentityClient;
        private readonly AppointmentDataContext context;

        public AwsApiCommandService(IOptions<AwsConfiguration> awsConfigurationOptions, IAwsCognitoIdentityClient awsCognitoIdentityClient, AppointmentDataContext context)
        {
            this.awsConfigurationOptions = awsConfigurationOptions;
            this.awsCognitoIdentityClient = awsCognitoIdentityClient;
            this.context = context;
        }

        public async Task<AdminCreateUserResponse> CreateAdminUserAsync(CreateAdminUserDto createAdminUserDto, CancellationToken cancellationToken)
        {
            var adminuser = await context.AdminUsers.FirstOrDefaultAsync(x => x.Username == createAdminUserDto.Username, cancellationToken);

            if (adminuser != null)
                throw new Common.Exceptions.UserExistException($"{createAdminUserDto.Username} exist");

            var _request = new AdminCreateUserRequest
            {
                UserPoolId = awsConfigurationOptions.Value.UserPoolId,
                Username = createAdminUserDto.Username,
                TemporaryPassword = createAdminUserDto.Password,
                UserAttributes = new List<AttributeType>
                {
                    new AttributeType {
                        Name = "email",
                        Value = createAdminUserDto.Email
                    },
                    new AttributeType {
                        Name = "email_verified",
                        Value = "true"
                    },
                    new AttributeType {
                        Name = "custom:role",
                        Value = "admin"
                    }
                }
            };

            return await awsCognitoIdentityClient.Client.AdminCreateUserAsync(_request, cancellationToken);
        }
    }
}