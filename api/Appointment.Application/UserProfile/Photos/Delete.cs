using System.Threading;
using System.Threading.Tasks;
using Appointment.Persistence;
using MediatR;
using System;
using Microsoft.Extensions.Logging;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;

namespace Appointment.Application.UserProfile.Photos
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string PhotoId { get; set; }
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
                    //     var user = await _userManager.Users
                    // .Include(u => u.AppUserProfile.Photos)
                    // .SingleOrDefaultAsync(u => u.UserName == _userAccessor.GetUsername());

                    //     var photo = user.AppUserProfile.Photos.FirstOrDefault(x => x.Id == request.PhotoId);

                    //     if (photo == null)
                    //         return Result<Unit>.Failure("Photo not found");

                    //     if (photo.IsMain)
                    //         return Result<Unit>.Failure("You cannot delete your main photo");

                    //     var result = _photoAccessor.DeletePhoto(photo.Id);

                    //     if (result == null)
                    //         return Result<Unit>.Failure("Problem deleting photo");

                    //     user.AppUserProfile.Photos.Remove(photo);

                    //     var success = await _context.SaveChangesAsync() > 0;

                    //     if (success) return Result<Unit>.Success(Unit.Value);

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