using Appointment.Application.Core;
using Appointment.Application.Core.Interfaces;
using Appointment.Domain.Main;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Persistence;
using Appointment.Persistence.Constants;
using Appointment.Persistence.Schema;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Dashboard.OffBoarding
{
    public class DeleteTenant
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string HeCode { get; set; }
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
            private readonly AppointmentMainDataContext _mainDataContext;
            private readonly ILogger<DeleteTenant> _logger;
            private readonly IMemoryCache _memoryCache;
            private readonly IHttpContextService _httpContextService;
            private readonly ITenantAccessor _tenantAccessor;

            public Handler(AppointmentDataContext context, AppointmentMainDataContext mainDataContext, ILogger<DeleteTenant> logger, IMemoryCache memoryCache, IHttpContextService httpContextService, ITenantAccessor tenantAccessor)
            {
                _context = context;
                _mainDataContext = mainDataContext;
                _logger = logger;
                _memoryCache = memoryCache;
                _httpContextService = httpContextService;
                _tenantAccessor = tenantAccessor;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var tenantMapping = await _mainDataContext.TenantMapping
                                                        .FirstOrDefaultAsync(x => x.HeCode == request.HeCode, cancellationToken);

                    if (tenantMapping == null) return Result<Unit>.Failure($"Tenant does not exist");

                    var _newContext = _tenantAccessor.GetAppointmentDataContext(tenantMapping.SchemaName);
                    _logger.LogInformation($"Removing {tenantMapping.SchemaName}");

                    await _newContext.GetInfrastructure().GetService<IMigrator>().MigrateAsync("0", cancellationToken);
                    await _newContext.Database.ExecuteSqlRawAsync($"DROP TABLE {tenantMapping.SchemaName}.__EFMigrationsHistory", cancellationToken);

                    _mainDataContext.TenantMapping.Remove(tenantMapping);

                    var result = await _mainDataContext.SaveChangesAsync() > 0;

                    if (!result) return Result<Unit>.Failure($"Fail to delete {request.HeCode} Main Mapping");

                    _logger.LogInformation($"{tenantMapping.SchemaName} removed");
                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                    return Result<Unit>.Failure(ex.Message);
                }
            }
        }

    }
}
