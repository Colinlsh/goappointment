using Appointment.Infrastructure.Common;
using Appointment.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Service
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid ServiceId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppointmentDataContext _context;
            private readonly ILogger<Delete> _logger;

            public Handler(AppointmentDataContext context, ILogger<Delete> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation($"Deleting service: {request.ServiceId}");
                    var service = await _context.Service
                .SingleOrDefaultAsync(x => x.Id == request.ServiceId, cancellationToken);

                    if (service == null) return Result<Unit>.Failure("Service Item does not exist");

                    _context.Service.Remove(service);

                    var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                    if (!result) return Result<Unit>.Failure("Failed to delete service item");

                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to delete service item: {ex.Message}", ex);
                    return Result<Unit>.Failure($"Failed to delete service item: {ex.Message}");
                }
            }
        }

    }
}
