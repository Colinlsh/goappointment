using Appointment.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Security
{
    public class IsHostRequirement : IAuthorizationRequirement
    {
    }

    public class IsHostRequirementHandler : AuthorizationHandler<IsHostRequirement>
    {
        private readonly AppointmentDataContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsHostRequirementHandler(AppointmentDataContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsHostRequirement requirement)
        {
            //var result = Guid.TryParse(context.User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);

            //if (!result) return Task.CompletedTask;

            //var activityId = Guid.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues
            //    .SingleOrDefault(x => x.Key == "id").Value?
            //    .ToString());

            //var attendee = _dbContext.ActivityAttendee
            //    .AsNoTracking()
            //    .SingleOrDefaultAsync(x => x.AppUserFK == userId && x.ActivityFK == activityId).Result;

            if (true) return Task.CompletedTask;

            else context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
