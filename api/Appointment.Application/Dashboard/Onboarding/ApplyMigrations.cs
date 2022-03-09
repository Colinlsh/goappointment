using Appointment.Application.Core;
using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Persistence;
using Appointment.Persistence.Schema;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Dashboard.Onboarding
{
    public class ApplyMigrations
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
            private readonly ILogger<ApplyMigrations> _logger;
            private readonly AppointmentMainDataContext _mainDataContext;
            private readonly IMemoryCache _memoryCache;
            private readonly IHttpContextService _httpContextService;
            private readonly ITenantAccessor _tenantAccessor;

            public Handler(AppointmentDataContext context, ILogger<ApplyMigrations> logger, AppointmentMainDataContext mainDataContext, IMemoryCache memoryCache, IHttpContextService httpContextService, ITenantAccessor tenantAccessor)
            {
                _context = context;
                _logger = logger;
                _mainDataContext = mainDataContext;
                _memoryCache = memoryCache;
                _httpContextService = httpContextService;
                _tenantAccessor = tenantAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var tenantMapping = await _mainDataContext.TenantMapping
                                                    .FirstOrDefaultAsync(x => x.HeCode == request.HeCode);

                if(tenantMapping == null) return Result<Unit>.Failure($"Tenant does not exist");

                var _newContext = _tenantAccessor.GetAppointmentDataContext(tenantMapping.SchemaName);

                // find if there are any pending migrations https://makolyte.com/ef-core-apply-migrations-programmatically/
                var pendingMigrations = await _newContext.Database.GetPendingMigrationsAsync(cancellationToken);

                if (!pendingMigrations.Any())
                {
                    return Result<Unit>.Failure("No more migrations");
                }
                _logger.LogInformation($"You have {pendingMigrations.Count()} pending migrations to apply.");
                _logger.LogInformation("Applying pending migrations now");

                var allMigrations = await _newContext.Database.GetAppliedMigrationsAsync(cancellationToken);

                await _newContext.Database.MigrateAsync(cancellationToken);
                
                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}
