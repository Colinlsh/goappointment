using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Appointment.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Infrastructure.Contracts;

namespace Appointment.Application.UserProfile.Photos
{
    public class Add
    {
        public class Command : IRequest<Result<AppUserPhotoDto>>
        {
            public IFormFile File { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<AppUserPhotoDto>>
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

            public async Task<Result<AppUserPhotoDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // var photoUploadResult = _photoAccessor.AddPhoto(request.File);

                    // var user = await _userManager.Users
                    //     .Include(u => u.AppUserProfile.Photos)
                    //     .SingleOrDefaultAsync(u => u.UserName == _userAccessor.GetUsername());

                    // var photo = new AppUserPhoto
                    // {
                    //     Url = photoUploadResult.Url,
                    //     Id = photoUploadResult.PublicId,
                    //     AppUserProfile = user.AppUserProfile
                    // };

                    // if (!user.AppUserProfile.Photos.Any(x => x.IsMain))
                    //     photo.IsMain = true;

                    // user.AppUserProfile.Photos.Add(photo);

                    // var success = await _context.SaveChangesAsync() > 0;

                    // var photoDto = _mapper.Map<AppUserPhotoDto>(photo);

                    // if (success) return Result<AppUserPhotoDto>.Success(photoDto);

                    return Result<AppUserPhotoDto>.Failure("Problem saving changes");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error in adding photos: {ex.Message}");
                    return Result<AppUserPhotoDto>.Failure($"Error in adding photos: {ex.Message}");
                }
            }
        }
    }
}