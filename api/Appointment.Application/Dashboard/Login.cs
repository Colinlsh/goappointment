using Appointment.Application.Dashboard.Dtos;
using Appointment.Persistence;
using Appointment.Persistence.Schema;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;

namespace Appointment.Application.Dashboard
{
    public class Login
    {
        public class Command : IRequest<Result<DashBoardUserDto>>
        {
            public DashboardLoginDto DashboardLoginDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<DashBoardUserDto>>
        {
            private readonly ITenantAccessor _tenantAccessor;
            private readonly AppointmentMainDataContext _mainDataContext;
            private readonly ILogger<Login> _logger;
            private readonly IMapper _mapper;
            private readonly IMemoryCache _memoryCache;

            public Handler(ITenantAccessor tenantAccessor, AppointmentMainDataContext mainDataContext, ILogger<Login> logger, IMapper mapper, IMemoryCache memoryCache)
            {
                _tenantAccessor = tenantAccessor;
                _mainDataContext = mainDataContext;
                _logger = logger;
                _mapper = mapper;
                _memoryCache = memoryCache;
            }

            public async Task<Result<DashBoardUserDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                // // check if user is super admin
                // var superAdmin = await _dbuserManager.FindByEmailAsync(request.DashboardLoginDto.Email);

                // if (superAdmin != null)
                // {
                //     return Result<DashBoardUserDto>.Success(new DashBoardUserDto
                //     {
                //         AppUserId = superAdmin.Id,
                //         TenantMappings = _mainDataContext.TenantMapping.GetFromCache(_memoryCache).Select(x => new TenantMappingDto { HeCode = x.HeCode }).ToList(),
                //         Roles = new List<AppUserRoleDto> { new AppUserRoleDto { Name = "SuperAdmin", RoleId = Guid.Empty } },
                //         Token = _tokenService.CreateToken(superAdmin)
                //     });
                // }

                // var allTenantDbContext = _tenantAccessor.Tenants.Select(x => _tenantAccessor.GetAppointmentDataContext(x)).ToList();

                // var users = _tenantAccessor.GetAllUsersByEmail(request.DashboardLoginDto.Email).ToList();

                // if (!users.Any())
                // {
                //     _logger.LogError($"User not found: {request.DashboardLoginDto.Email}");
                //     return Result<DashBoardUserDto>.Failure($"User not found: {request.DashboardLoginDto.Email}");
                // }

                // var _validatedUser = new KeyValuePair<string, Domain.Tenant.AppUser>();
                // // validate user password and get correct user
                // foreach (var user in users)
                // {
                //     var passwordValidationResult = await _signInManager.CheckPasswordSignInAsync(user.Value, request.DashboardLoginDto.Password, false);

                //     if (!passwordValidationResult.Succeeded && users.Last().Value == user.Value)
                //     {
                //         _logger.LogError($"Wrong password: {user.Value.UserName}");
                //         return Result<DashBoardUserDto>.Failure($"Wrong password: {user.Value.UserName}");
                //     }
                //     else if (passwordValidationResult.Succeeded)
                //     {
                //         _validatedUser = user;
                //         break;
                //     }
                // }

                // return Result<DashBoardUserDto>.Success(new DashBoardUserDto
                // {
                //     AppUserId = _validatedUser.Value.Id,
                //     TenantMappings = new List<TenantMappingDto>() { new TenantMappingDto { HeCode = _validatedUser.Key } },
                //     Roles = _mapper.Map<IList<AppUserRoleDto>>(_validatedUser.Value.AppUserRoles.Select(x => x.AppUserRole)),
                //     Token = _tokenService.CreateToken(_validatedUser.Value)
                // });

                return Result<DashBoardUserDto>.Success(null);
            }
        }


    }
}
