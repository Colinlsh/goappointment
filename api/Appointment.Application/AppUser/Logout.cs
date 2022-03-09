using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;

namespace Appointment.Application.AppUser
{
    public class Logout
    {

        public class Command : IRequest<Result<bool>>
        {
            public string Email { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly ILogger<Logout> logger;

            public Handler(ILogger<Logout> logger)
            {
                this.logger = logger;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // var user = await _userManager.FindByEmailAsync(request.Email);
                    // var result = await _userManager.UpdateSecurityStampAsync(user);

                    // if (!result.Succeeded)
                    // {
                    //     _logger.LogInformation($"Failed to log out user: {request.Email}");
                    //     return Result<bool>.Failure("Fail to log out user");
                    // }

                    return Result<bool>.Success(true);
                }
                catch (Exception error)
                {
                    logger.LogError(error, $"{error.Message}");
                    return Result<bool>.Failure("Fail to log out user");
                }
            }
        }

    }
}
