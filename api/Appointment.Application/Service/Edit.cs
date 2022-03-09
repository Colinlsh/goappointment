using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Service
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ServiceDto ServiceDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IServicesCommandService servicesCommandService;
            private readonly ILogger<Edit> logger;

            public Handler(IServicesCommandService servicesCommandService, ILogger<Edit> logger)
            {
                this.servicesCommandService = servicesCommandService;
                this.logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    logger.LogInformation($"Creating service item {request.ServiceDto}");

                    var result = await servicesCommandService.EditService(request.ServiceDto, cancellationToken);

                    if (!result) return Result<Unit>.Failure("Failed to create service");

                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception ex)
                {
                    logger.LogError($"Failed creating service {ex.Message}", ex);
                    return Result<Unit>.Failure($"Failed to create service: {ex.Message}");
                }
            }
        }

    }
}
