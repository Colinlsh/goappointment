using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Appointment
{
    public class List
    {

        public class Query : IRequest<Result<IList<AppointmentDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<IList<AppointmentDto>>>
        {
            private readonly ILogger<List> _logger;
            private readonly IAppointmentRequestService _appointmentRequestService;

            public Handler(ILogger<List> logger, IAppointmentRequestService appointmentReadService)
            {
                _logger = logger;
                _appointmentRequestService = appointmentReadService;
            }

            public async Task<Result<IList<AppointmentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation($"Getting appointments");

                    var appointmentDtos = await _appointmentRequestService.GetAppointmentDtosAsync(cancellationToken);

                    if (appointmentDtos != null)
                        return Result<IList<AppointmentDto>>.Success(appointmentDtos);

                    _logger.LogError("No appointments found");
                    return Result<IList<AppointmentDto>>.Failure("No appointments found");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Get appointments error: {ex.Message}", ex);
                    return Result<IList<AppointmentDto>>.Failure($"Get appointments error: {ex.Message}");
                }
            }
        }


    }
}
