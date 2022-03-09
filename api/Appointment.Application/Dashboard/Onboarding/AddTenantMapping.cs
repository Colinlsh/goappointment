using Appointment.Application.Core;
using Appointment.Application.Core.Helpers;
using Appointment.Application.Core.Interfaces;
using Appointment.Domain.Main;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Persistence;
using Appointment.Persistence.Extentions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Dashboard.Onboarding
{
    public class AddTenantMapping
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string TenantCode { get; set; }
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
            private readonly IMemoryCache _memoryCache;
            private readonly IHttpContextService _httpContextService;
            private readonly ILogger<AddTenantMapping> _logger;
            private readonly IHostApplicationLifetime _hostApplicationLifetime;

            public Handler(AppointmentMainDataContext mainDataContext, IMemoryCache memoryCache, IHttpContextService httpContextService, ILogger<AddTenantMapping> logger, IHostApplicationLifetime hostApplicationLifetime)
            {
                _mainDatacontext = mainDataContext;
                _memoryCache = memoryCache;
                _httpContextService = httpContextService;
                _logger = logger;
                _hostApplicationLifetime = hostApplicationLifetime;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // get latest tenant
                var tenantMapping = _mainDatacontext.TenantMapping
                    .GetFromCache(_memoryCache)
                    .OrderByDescending(x => x.TenantIndex);

                if(tenantMapping.Any())
                {
                    var _oldTenant = tenantMapping.FirstOrDefault(x => x.TenantCode == request.TenantCode);

                    if (_oldTenant != null) return Result<Unit>.Failure("Tenant already exist, please try another code name");
                }

                // create new schema
                var _newTenant = new TenantMapping
                {
                    TenantCode = request.TenantCode,
                    SchemaName = tenantMapping.Any() ? Helpers.GetNewSchema(tenantMapping.FirstOrDefault().SchemaName) : "Tenant_001",
                    CreateBy = _httpContextService.GetUsername(),
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                    UpdateBy = _httpContextService.GetUsername(),
                    HeCode = tenantMapping.Any() ? Helpers.GetNewHeCode(tenantMapping.FirstOrDefault().HeCode) : "AP0001",
                    DBName = tenantMapping.Any() ? tenantMapping.FirstOrDefault().DBName : "Appointment_R0.1",
                    DBServer = tenantMapping.Any() ? tenantMapping.FirstOrDefault().DBServer : "db",
                    DBUsername = request.TenantCode,
                    DBUserPassword = request.TenantCode,
                    TenantIndex = tenantMapping.Count() + 1
                };

                await _mainDatacontext.TenantMapping.AddAsync(_newTenant);

                var result = await _mainDatacontext.SaveChangesAsync(cancellationToken) > 0;

                if (!result) return Result<Unit>.Failure("Failed to create tenant");

                // forcefully restart app to refresh cache.
                // this does not seem like the best way to do it but it works for now. 
                _hostApplicationLifetime.StopApplication();

                return Result<Unit>.Success(Unit.Value, $"{request.TenantCode} created, you may now start registering");
            }
        }

    }
}
