using Appointment.Domain.Enums;
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
    public class Deactivate
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ILogger<Deactivate> logger;
            private readonly AppointmentDataContext context;

            public Handler(ILogger<Deactivate> logger, AppointmentDataContext context)
            {
                this.logger = logger;
                this.context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await context.AppUser.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

                    if (user == null)
                    {
                        logger.LogInformation($"User Id: {request.UserId} not found");
                        return Result<Unit>.Failure("User not found!");
                    }

                    user.ActiveStatus = ActiveStatus.InActive.GetDescription();

                    var result = await context.SaveChangesAsync(cancellationToken) > 0;

                    if (!result)
                    {
                        logger.LogError($"Fail to deactivate user: {request.UserId}");
                        return Result<Unit>.Failure("Failed to deactivate user");
                    }

                    logger.LogInformation($"Deactivated user: {request.UserId}");
                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception error)
                {
                    logger.LogError(error, $"Error: {error.Message}");
                    return Result<Unit>.Failure($"Error: {error.Message}");
                }
            }
        }
    }
}
