using Appointment.Domain.Tenant;
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
    public class ServiceItemCreate
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
            private readonly ILogger<ServiceItemCreate> _logger;

            public Handler(AppointmentDataContext context, IMapper mapper, ILogger<ServiceItemCreate> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation($"Creating service item {request.ServiceItemDto}");

                    var serviceItems = await _context.ServiceItem.ToListAsync(cancellationToken);

                    var serviceItem = serviceItems.SingleOrDefault(x => x.Title == request.ServiceItemDto.Title);

                    if (serviceItem != null) return Result<Unit>.Failure("Service item exist");

                    serviceItem = _mapper.Map<ServiceItem>(request.ServiceItemDto);

                    serviceItem.SortOrder = serviceItems.Count + 1;
                    serviceItem.EffectiveStartDate = DateTime.Now;
                    serviceItem.CreateDate = DateTime.Now;
                    serviceItem.UpdateDate = DateTime.Now;

                    await _context.ServiceItem.AddAsync(serviceItem, cancellationToken);

                    var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                    if (!result) return Result<Unit>.Failure("Failed to create service item");

                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed creating service item {ex.Message}", ex);
                    return Result<Unit>.Failure($"Exception: {ex.Message}");
                }
            }
        }

    }
}
