using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Appointment.Application.Core;
using Appointment.Application.Core.Interfaces;
using Appointment.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;

namespace Appointment.Application.Activities.Photos
{
    public class Add
    {
        public class Command : IRequest<Result<ActivityPhotoDto>>
        {
            public IFormFile File { get; set; }
            public Guid ActivityId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<ActivityPhotoDto>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IHttpContextService _userAccessor;
            private readonly IPhotoAccessorService _photoAccessor;
            private readonly IMapper _mapper;
            private readonly ILogger<Add> _logger;

            public Handler(AppointmentDataContext context, IHttpContextService userAccessor, IPhotoAccessorService photoAccessor, IMapper mapper, ILogger<Add> logger)
            {
                _photoAccessor = photoAccessor;
                _mapper = mapper;
                _logger = logger;
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<ActivityPhotoDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var photoUploadResult = _photoAccessor.AddPhoto(request.File);

                    // var user = await _userManager.Users
                    //     .Include(u => u.Activities)
                    //     .SingleOrDefaultAsync(u => u.UserName == _userAccessor.GetUsername());

                    // var activity = await _context.Activity
                    //     .Include(a => a.ActivityPhotos)
                    //     .SingleOrDefaultAsync(a => a.ActivityId == request.ActivityId);

                    // // check if user is the host
                    // if (activity.Attendees.First(x => x.IsHost).AppUser.Id != user.Id)
                    //     return Result<ActivityPhotoDto>.Failure("Only host can add photos to activity");

                    // var photo = new ActivityPhoto
                    // {
                    //     Url = photoUploadResult.Url,
                    //     PhotoId = photoUploadResult.PublicId,
                    //     Activity = activity
                    // };

                    // if (!activity.ActivityPhotos.Any(x => x.IsMain))
                    //     photo.IsMain = true;

                    // activity.ActivityPhotos.Add(photo);

                    // var success = await _context.SaveChangesAsync() > 0;

                    // var photoDto = _mapper.Map<ActivityPhotoDto>(photo);

                    // if (success) return Result<ActivityPhotoDto>.Success(photoDto);

                    return Result<ActivityPhotoDto>.Failure("Problem saving changes");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error in adding photos: {ex.Message}");
                    return Result<ActivityPhotoDto>.Failure($"Error in adding photos: {ex.Message}");
                }
            }
        }
    }
}