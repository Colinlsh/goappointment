using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using AutoMapper;
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
    public class List
    {

        public class Query : IRequest<Result<IList<ServiceDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<IList<ServiceDto>>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<List> _logger;

            public Handler(AppointmentDataContext context, IMapper mapper, ILogger<List> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<IList<ServiceDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation($"Getting services");

                    var services = await _context.Service
                        .Include(s => s.ServiceItems).ThenInclude(s => s.ServiceItem)
                        .ToListAsync(cancellationToken);

                    var serviceDtos = services.Select(x =>
                    {
                        var serviceItemDtos = _mapper.Map<IList<ServiceItemDto>>(x.ServiceItems.Select(si => si.ServiceItem));

                        return new ServiceDto
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Description = x.Description,
                            ServiceItemDtos = serviceItemDtos
                        };
                    }).ToList();

                    if (services != null)
                        return Result<IList<ServiceDto>>.Success(serviceDtos);

                    _logger.LogError("No services found");
                    return Result<IList<ServiceDto>>.Failure("No services found");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Get services error: {ex.Message}", ex);
                    return Result<IList<ServiceDto>>.Failure($"Get services error: {ex.Message}");
                }
            }
        }

    }
}
