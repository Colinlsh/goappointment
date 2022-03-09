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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Service
{
    public class Create
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
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<Create> _logger;

            public Handler(AppointmentDataContext context, IMapper mapper, ILogger<Create> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation($"Creating new service {request.ServiceDto.Title}");
                    // find out if service exist
                    var service = await _context.Service
                        .Include(s => s.ServiceItems)
                        .FirstOrDefaultAsync(x => x.Title == request.ServiceDto.Title, cancellationToken);

                    if (service != null)
                        return Result<Unit>.Failure("Service already exist");

                    // service does not exist, start to create mapping from dto to domain entities
                    // look for individual service items
                    var serviceItems = _context.ServiceItem.ToList()
                        .Where(si => request.ServiceDto.ServiceItemDtos.Any(sidto => sidto.Id == si.Id));

                    var _newservice = _mapper.Map<Domain.Tenant.Service>(request.ServiceDto);

                    _newservice.EffectiveStartDate = DateTime.Now;
                    _newservice.CreateDate = DateTime.Now;
                    _newservice.UpdateDate = DateTime.Now;
                    _newservice.SortOrder = _context.Service.Count() + 1;
                    _newservice.ServiceItems = new List<ServiceServiceItem>();

                    // add join table items
                    foreach (var item in serviceItems)
                    {
                        _context.Entry(item).State = EntityState.Unchanged;
                        _newservice.ServiceItems.Add(new ServiceServiceItem
                        {
                            Service = _newservice,
                            ServiceItem = item,
                        });
                    }

                    // create and add new service first then add in the join table items, if not ef core will do a cascade create
                    _context.Service.Add(_newservice);

                    var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                    if (!result) return Result<Unit>.Failure("Failed to create service");

                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to create service: {ex.Message} {ex.InnerException}", ex);
                    return Result<Unit>.Failure($"Failed to create service: {ex.Message} {ex.InnerException}");
                }
            }
        }

    }
}
