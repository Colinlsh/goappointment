using System;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Domain.Enums;
using Appointment.Infrastructure.Common.Helpers;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.AdminUser
{
    public class AdminUserCommandService : IAdminUserCommandService
    {
        private readonly AppointmentDataContext context;
        private readonly IMapper mapper;
        public AdminUserCommandService(AppointmentDataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<bool> CreateAdminUserAsync(CreateAdminUserDto createAdminUserDto, CancellationToken cancellationToken)
        {
            // create userprofile
            var user = mapper.Map<Domain.Tenant.AdminUser>(createAdminUserDto);

            var userProfile = new Domain.Tenant.UserProfile
            {
                AdminUser = user,
                DisplayName = createAdminUserDto.Username,
                Gender = createAdminUserDto.Gender
            };

            if (!DateTime.TryParse(createAdminUserDto.Birthdate, out DateTime birthdate))
                return false;

            userProfile.Age = AgeCalculator.GetCurrentAge(birthdate);

            user.UserProfile = userProfile;

            user.ActiveStatus = ActiveStatus.Active.GetDescription();

            user.CreateDate = DateTime.UtcNow;
            user.UpdateDate = DateTime.UtcNow;
            user.EffectiveEndDate = DateTime.MaxValue;
            user.EffectiveStartDate = DateTime.UtcNow;

            await context.AdminUsers.AddAsync(user, cancellationToken);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
                return false;

            return true;
        }
    }
}