using Amazon.CognitoIdentityProvider.Model;
using Appointment.Infrastructure.Aws.Models;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.AppUser
{
    public class AppUserRequestService : IAppUserRequestService
    {
        private readonly AppointmentDataContext context;
        private readonly IAwsCognitoIdentityClient awsCognitoIdentityClient;
        private readonly IOptions<AwsConfiguration> awsConfigurationOptions;

        public AppUserRequestService(AppointmentDataContext context, AppointmentMainDataContext mainContext, IAwsCognitoIdentityClient awsCognitoIdentityClient, IOptions<AwsConfiguration> awsConfigurationOptions)
        {
            this.awsConfigurationOptions = awsConfigurationOptions;
            this.awsCognitoIdentityClient = awsCognitoIdentityClient;
            this.context = context;
        }

        public async Task<Guid> GetAppUserId(string username)
        {
            var user = await context.AppUser.FirstOrDefaultAsync(x => x.Username == username);

            if (user != null)
                return user.Id;

            var mainUser = await context.AdminUsers.FirstOrDefaultAsync(x => x.Username == username);

            return mainUser.Id;
        }

        public async Task<IList<UserDto>> GetUsers(CancellationToken cancellationToken)
        {
            var users = new List<UserDto>();
            var request = new ListUsersRequest
            {
                UserPoolId = awsConfigurationOptions.Value.UserPoolId,
                Limit = 60,
            };

            var g = await awsCognitoIdentityClient.Client.ListUsersAsync(request, cancellationToken);

            if (!g.Users.Any())
                return null;
            else
            {
                var _users = g.Users;

                return users;
            }

            // var users = await _userManager.Users
            //                             .Include(u => u.AppUserProfile)
            //                             .Include(u => u.AppUserRoles).ThenInclude(u => u.AppUserRole)
            //                             .ToListAsync(cancellationToken);

            // // map fk to common table
            // var userDtos = users.MapToUserDto(_mapper, _mainContext, _memoryCache);

            return new List<UserDto>();
        }
    }
}
