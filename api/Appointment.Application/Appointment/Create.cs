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
    public class Create
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
            private readonly ILogger<Create> _logger;
            private readonly IAppointmentRequestService _appointmentRequestService;
            private readonly IAppointmentCommandService _appointmentCommandService;

            public Handler(ILogger<Create> logger, IAppointmentRequestService appointmentRequestService, IAppointmentCommandService appointmentCommandService)
            {
                _logger = logger;
                _appointmentRequestService = appointmentRequestService;
                _appointmentCommandService = appointmentCommandService;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // check if appointment exist
                    var appointment = await _appointmentRequestService.GetAppointment_ByTitleAsync(request.AppointmentDto.Title, cancellationToken);

                    if (appointment != null)
                        return Result<Unit>.Failure("Appointment already exist");

                    _logger.LogInformation($"Creating new appointment {request.AppointmentDto.Title}");
                    // create appointment entity
                    var result = await _appointmentCommandService.CreateAppointmentAsync(request.AppointmentDto, cancellationToken);

                    if (!result) return Result<Unit>.Failure("Failed to create appointment");

                    return Result<Unit>.Success(Unit.Value, "Appointment created");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to new appointment {request.AppointmentDto.Title}", ex);
                    return Result<Unit>.Failure($"Exception: {ex.Message}");
                }
            }
        }

    }
}
