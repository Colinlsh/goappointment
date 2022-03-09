using Appointment.Infrastructure.Common;
using Appointment.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.AppUser
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ILogger<Delete> logger;
            private readonly AppointmentDataContext context;

            public Handler(ILogger<Delete> logger, AppointmentDataContext context)
            {
                this.logger = logger;
                this.context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await context.AppUser.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

                    if (user != null)
                    {
                        context.AppUser.Remove(user);

                        var result = await context.SaveChangesAsync(cancellationToken) > 0;

                        if (!result)
                        {
                            logger.LogError($"Failed to delete user");
                            return Result<Unit>.Failure("Failed to delete user");
                        }

                        return Result<Unit>.Success(Unit.Value);
                    }

                    logger.LogInformation($"User Id: {request.UserId} not found");

                    return Result<Unit>.Failure("User not found");
                }
                catch (Exception error)
                {
                    logger.LogError(error, $"Error: {error.Message}");
                    return Result<Unit>.Failure($"{error.Message}");
                }
            }
        }
    }
}
