using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Application.Core;
using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Appointment.Application.Activities.Photos
{
    public class SetMain
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string PhotoId { get; set; }
            public Guid ActivityId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IHttpContextService _userAccessor;
            private readonly ILogger<SetMain> _logger;

            public Handler(AppointmentDataContext context, IHttpContextService userAccessor, ILogger<SetMain> logger)
            {
                _userAccessor = userAccessor;
                _logger = logger;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // var user = await _userManager.Users
                    //                 .SingleOrDefaultAsync(u => u.UserName == _userAccessor.GetUsername());

                    // var activity = await _context.Activity
                    //     .Include(a => a.Attendees)
                    //     .Include(a => a.ActivityPhotos)
                    //     .SingleOrDefaultAsync(a => a.ActivityId == request.ActivityId);

                    // // check if user is the host
                    // if (activity.Attendees.First(x => x.IsHost).AppUser.Id != user.Id)
                    //     return Result<Unit>.Failure("Only host can set photo to main in activity");

                    // var photo = activity.ActivityPhotos.FirstOrDefault(x => x.PhotoId == request.PhotoId);

                    // if (photo == null)
                    //     Result<Unit>.Failure("Not found");

                    // var currentMain = activity.ActivityPhotos.FirstOrDefault(x => x.IsMain);

                    // currentMain.IsMain = false;
                    // photo.IsMain = true;

                    // var success = await _context.SaveChangesAsync() > 0;

                    // if (success) return Result<Unit>.Success(Unit.Value);

                    return Result<Unit>.Failure("Problem saving changes");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error in setting photo main: {ex.Message}");
                    return Result<Unit>.Failure($"Error in setting photo main: {ex.Message}");
                }
            }
        }
    }
}