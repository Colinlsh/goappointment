using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Application.Core.Interfaces;
using Appointment.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Appointment.Application.Core;
using System;
using Microsoft.Extensions.Logging;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;

namespace Appointment.Application.Activities.Photos
{
    public class Delete
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
            private readonly IPhotoAccessorService _photoAccessor;
            private readonly ILogger<Delete> _logger;
            public Handler(AppointmentDataContext context, IHttpContextService userAccessor, IPhotoAccessorService photoAccessor, ILogger<Delete> logger)
            {
                _photoAccessor = photoAccessor;
                _logger = logger;
                _userAccessor = userAccessor;
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
                    //     return Result<Unit>.Failure("Only host can delete photos from activity");

                    // var photo = activity.ActivityPhotos.FirstOrDefault(x => x.PhotoId == request.PhotoId);

                    // if (photo == null)
                    //     return Result<Unit>.Failure("Not found");

                    // if (photo.IsMain)
                    //     return Result<Unit>.Failure("You cannot delete your main photo");

                    // var result = _photoAccessor.DeletePhoto(photo.PhotoId);

                    // if (result == null)
                    //     return Result<Unit>.Failure("Problem deleting photo");

                    // activity.ActivityPhotos.Remove(photo);

                    // var success = await _context.SaveChangesAsync() > 0;

                    // if (success) return Result<Unit>.Success(Unit.Value);

                    return Result<Unit>.Failure("Problem saving changes");

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error in deleting photo: {ex.Message}");
                    return Result<Unit>.Failure($"Error in deleting photo: {ex.Message}");
                }
            }
        }
    }
}