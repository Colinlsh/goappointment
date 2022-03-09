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
    public class ServiceItemDelete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid ServiceItemId { get; set; }
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
            private readonly ILogger<ServiceItemDelete> _logger;

            public Handler(AppointmentDataContext context, ILogger<ServiceItemDelete> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation($"Deleting service item: {request.ServiceItemId}");
                    var serviceItem = await _context.ServiceItem
                .SingleOrDefaultAsync(x => x.Id == request.ServiceItemId, cancellationToken);

                    if (serviceItem == null) return Result<Unit>.Failure("Service Item does not exist");

                    _context.ServiceItem.Remove(serviceItem);

                    var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                    if (!result) return Result<Unit>.Failure("Failed to create user");

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
