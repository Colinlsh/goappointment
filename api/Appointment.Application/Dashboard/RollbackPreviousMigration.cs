using Appointment.Infrastructure.Common;
using Appointment.Persistence;
using Appointment.Persistence.Schema;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Dashboard
{
    public class RollbackPreviousMigration
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
            private readonly AppointmentMainDataContext _mainDataContext;
            private readonly ILogger<RollbackPreviousMigration> _logger;
            private readonly ITenantAccessor _tenantAccessor;

            public Handler(AppointmentMainDataContext mainDataContext, ILogger<RollbackPreviousMigration> logger, ITenantAccessor tenantAccessor)
            {
                _mainDataContext = mainDataContext;
                _logger = logger;
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

                    // find if there are any pending migrations https://makolyte.com/ef-core-apply-migrations-programmatically/
                    var allMigrations = await _newContext.Database.GetAppliedMigrationsAsync(cancellationToken);

                    if (allMigrations.Count() < 2)
                        return Result<Unit>.Failure("No more migrations to rollback");

                    var secondLastAppliedMigration = allMigrations.ElementAt(allMigrations.Count() - 2);
                    _logger.LogInformation($"Applying migrations back to {secondLastAppliedMigration}");

                    await _newContext.GetInfrastructure().GetService<IMigrator>().MigrateAsync(secondLastAppliedMigration, cancellationToken);

                    _logger.LogInformation($"You're on schema version: {secondLastAppliedMigration}");

                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to rollback: {ex.Message}", ex);
                    return Result<Unit>.Failure($"Failed to rollback: {ex.Message}");
                }
            }
        }

    }
}
