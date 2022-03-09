using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Service
{
    public class ServiceItemEdit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ServiceItemDto ServiceItemDto { get; set; }
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
            private readonly IMapper _mapper;
            private readonly ILogger<ServiceItemEdit> _logger;

            public Handler(AppointmentDataContext context, IMapper mapper, ILogger<ServiceItemEdit> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation($"Editing service item {request.ServiceItemDto}");
                    var serviceItems = await _context.ServiceItem.ToListAsync(cancellationToken);

                    var serviceItem = serviceItems.FirstOrDefault(si => si.Id == request.ServiceItemDto.Id);

                    if (serviceItem == null) return Result<Unit>.Failure($"Service item {request.ServiceItemDto} does not exist");

                    _mapper.Map(request.ServiceItemDto, serviceItem);

                    var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                    if (!result) return Result<Unit>.Failure($"Failed to update service item {request.ServiceItemDto}");

                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to update service item: {ex.Message}", ex);
                    return Result<Unit>.Failure($"Exception: {ex.Message}");
                }
            }
        }

    }
}
