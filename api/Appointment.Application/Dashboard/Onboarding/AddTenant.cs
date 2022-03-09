using Appointment.Application.Core;
using Appointment.Application.Core.Interfaces;
using Appointment.Domain.Enums;
using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Persistence;
using Appointment.Persistence.Extentions;
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

namespace Appointment.Application.Dashboard.Onboarding
{
    public class AddTenant
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
            private readonly AppointmentMainDataContext _mainDatacontext;
            private readonly AppointmentDataContext _context;
            private readonly ILogger<AddTenant> _logger;
            private readonly ITenantAccessor _tenantAccessor;

            public Handler(AppointmentMainDataContext mainDatacontext, AppointmentDataContext context, ILogger<AddTenant> logger, IHttpContextService httpContextService, ITenantAccessor tenantAccessor)
            {
                _mainDatacontext = mainDatacontext;
                _context = context;
                _logger = logger;
                _tenantAccessor = tenantAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // get latest tenant
                var tenantMapping = _mainDatacontext.TenantMapping
                    .First(x => x.HeCode == request.HeCode);

                var _newContext = _tenantAccessor.GetAppointmentDataContext(tenantMapping.SchemaName);

                // find if there are any pending migrations
                _logger.LogInformation($"Creating tenant tables for {tenantMapping.SchemaName}");
                _logger.LogInformation("Applying pending migrations now");

                await _newContext.Database.MigrateAsync(cancellationToken);

                // if (!_newContext.Roles.Any())
                // {
                //     var roles = new List<AppUserRole>
                //     {
                //         new AppUserRole
                //         {
                //             Name = RoleType.SuperAdmin.GetDescription(),
                //             NormalizedName = RoleType.SuperAdmin.GetDescription().ToUpper(),
                //             SortOrder = 1,
                //         },
                //         new AppUserRole
                //         {
                //             Name = RoleType.TenantOwner.GetDescription(),
                //             NormalizedName = RoleType.TenantOwner.GetDescription().ToUpper(),
                //             SortOrder = 2
                //         },
                //         new AppUserRole
                //         {
                //             Name = RoleType.Customer.GetDescription(),
                //             NormalizedName = RoleType.Customer.GetDescription().ToUpper(),
                //             SortOrder = 3,
                //         }
                //     };

                //     await _newContext.AppUserRole.AddRangeAsync(roles, cancellationToken);

                //     await _newContext.SaveChangesAsync(cancellationToken);
                // }

                _logger.LogInformation("Migrations applied");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}
