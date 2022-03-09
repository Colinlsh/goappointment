using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Appointment
{
    public class Update
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AppointmentDto AppointmentDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ILogger<Update> _logger;
            private readonly IAppointmentRequestService _appointmentRequestService;
            private readonly IAppointmentCommandService _appointmentCommandService;

            public Handler(ILogger<Update> logger, IAppointmentRequestService appointmentRequestService, IAppointmentCommandService appointmentCommandService)
            {
                _logger = logger;
                _appointmentRequestService = appointmentRequestService;
                _appointmentCommandService = appointmentCommandService;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation($"Updating appointment {request.AppointmentDto}");
                    var appointment = await _appointmentRequestService.GetAppointment_ByAppointmentIDAsync(request.AppointmentDto.Id,cancellationToken);

                    if (appointment == null) return Result<Unit>.Failure("Appointment does not exist");

                    var result = await _appointmentCommandService.UpdateAppointmentAsync(appointment, request.AppointmentDto, cancellationToken);

                    if (!result) return Result<Unit>.Failure("Failed to update appointment");

                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to update appointment {ex.Message}", ex);
                    return Result<Unit>.Failure($"Failed to update appointment: {ex.Message}");
                }
            }
        }
    }
}
