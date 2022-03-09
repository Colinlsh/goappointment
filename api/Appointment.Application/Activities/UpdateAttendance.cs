using FluentValidation;
using Appointment.Application.Core;
using Appointment.Application.Core.Interfaces;
using Appointment.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;

namespace Appointment.Application.Activities
{
    public class UpdateAttendance
    {

        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IHttpContextService _userAccessor;

            public Handler(AppointmentDataContext context, IHttpContextService userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // var activity = await _context.Activity
                //     .Include(a => a.Attendees)
                //     .ThenInclude(u => u.AppUser)
                //     .FirstOrDefaultAsync(x => x.ActivityId == request.Id, cancellationToken);

                // if(activity != null)
                // {
                //     var user = await _userManager.FindByNameAsync(_userAccessor.GetUsername());

                //     var hostUsername = string.Empty;

                //     if (user != null)
                //         hostUsername = activity.Attendees.FirstOrDefault(x => x.IsHost)?.AppUser?.UserName;
                //     else
                //         return null;

                //     var attendance = activity.Attendees.FirstOrDefault(x => x.AppUser.UserName == user.UserName);

                //     if(attendance != null && hostUsername == user.UserName)
                //         activity.IsCancelled = !activity.IsCancelled;

                //     if (attendance != null && hostUsername != user.UserName)
                //         activity.Attendees.Remove(attendance);

                //     if(attendance == null)
                //     {
                //         attendance = new ActivityAttendee
                //         {
                //             AppUser = user,
                //             Activity = activity,
                //             IsHost = false
                //         };

                //         activity.Attendees.Add(attendance);
                //     }
                // }
                // else
                //     return null;

                var result = await _context.SaveChangesAsync() > 0;

                return result ?
                    Result<Unit>.Success(Unit.Value) :
                    Result<Unit>.Failure("Problem updateing attendance");
            }
        }

    }
}
