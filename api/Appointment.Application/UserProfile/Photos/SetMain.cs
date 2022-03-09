using System;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Appointment.Application.UserProfile.Photos
{
    public class SetMain
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
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
                    //                 .Include(u => u.AppUserProfile.Photos)
                    //                 .SingleOrDefaultAsync(u => u.UserName == _userAccessor.GetUsername());

                    // var photo = user.AppUserProfile.Photos.FirstOrDefault(x => x.Id == request.Id);

                    // if (photo == null)
                    //     Result<Unit>.Failure("Not found");

                    // var currentMain = user.AppUserProfile.Photos.FirstOrDefault(x => x.IsMain);

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