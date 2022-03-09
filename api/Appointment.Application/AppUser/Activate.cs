using Appointment.Application.Core;
using Appointment.Application.Core.Helpers;
using Appointment.Domain.Enums;
using Appointment.Infrastructure.Common;
using Appointment.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.AppUser
{
    public class Activate
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppointmentDataContext _context;
            private readonly ILogger<Activate> _logger;

            public Handler(AppointmentDataContext context, ILogger<Activate> logger)
            {
                _context = context;

                _logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // var user = await _userManager.FindByIdAsync(request.UserId.ToString());

                    // if (user != null)
                    // {
                    //     user.ActiveStatus = ActiveStatus.Active.GetDescription();

                    //     var result = await _userManager.UpdateAsync(user);

                    //     if (!result.Succeeded)
                    //     {
                    //         _logger.LogError($"Fail to activate user: {request.UserId}");
                    //         return Result<Unit>.Failure("Failed to activate user");
                    //     }

                    //     return Result<Unit>.Success(Unit.Value);
                    // }

                    // _logger.LogInformation($"User Id: {request.UserId} not found");
                    return Result<Unit>.Failure("User not found");
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"{error.Message}");
                    return Result<Unit>.Failure($"Error: {error.Message}");
                }
            }
        }

    }
}
