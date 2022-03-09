using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Persistence;
using Microsoft.Extensions.Caching.Memory;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Infrastructure.Contracts;

namespace Appointment.Application.AppUser
{
    public class Register
    {
        public class Command : IRequest<Result<Unit>>
        {
            public RegisterDto RegisterDto { get; set; }
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
            private readonly IMemoryCache _memoryCache;
            private readonly IMapper _mapper;
            private readonly ILogger<Register> _logger;
            private readonly IHttpContextService _httpContextService;
            private readonly IEmailSenderService _emailSenderService;

            public Handler(AppointmentDataContext context, AppointmentMainDataContext mainDataContext, IMemoryCache memoryCache, IMapper mapper, ILogger<Register> logger, IHttpContextService httpContextService, IEmailSenderService emailSenderService)
            {
                _context = context;
                _mainDataContext = mainDataContext;
                _memoryCache = memoryCache;
                _mapper = mapper;
                _logger = logger;
                _httpContextService = httpContextService;
                _emailSenderService = emailSenderService;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // // validation
                    // if (await _userManager.Users.AnyAsync(x => x.Email == request.RegisterDto.Email, cancellationToken))
                    // {
                    //     _logger.LogInformation($"Failed to Register, Email: {request.RegisterDto.Email} taken");
                    //     return Result<Unit>.Failure("Email taken");
                    // }
                    // if (await _userManager.Users.AnyAsync(x => x.UserName == request.RegisterDto.Username, cancellationToken))
                    // {
                    //     _logger.LogInformation($"Failed to Register, Username: {request.RegisterDto.Username} taken");
                    //     return Result<Unit>.Failure("Username taken");
                    // }

                    // var birthdate = DateTime.Parse(request.RegisterDto.Birthdate);

                    // var age = birthdate.GetCurrentAge();

                    // // map from dto to domain entity
                    // var _newUser = _mapper.Map<Domain.Tenant.AppUser>(request.RegisterDto);
                    // // fill up other information
                    // _newUser.CreateDate = DateTime.Now;
                    // _newUser.UpdateDate = DateTime.Now;

                    // CreateUserProfile(request, age, _newUser);

                    // _newUser.ActiveStatus = ActiveStatus.Active.GetDescription();

                    // // insert role
                    // var appuserroles = await _context.AppUserRole.ToListAsync(cancellationToken);

                    // var roles = appuserroles.Where(x => request.RegisterDto.AppUserRoleDtos.Any(z => z.RoleId == x.Id));

                    // _newUser.AppUserRoles = new List<AppUserAppUserRole>();
                    // foreach (var item in roles)
                    // {
                    //     _context.Entry(item).State = EntityState.Unchanged;
                    //     _newUser.AppUserRoles.Add(new AppUserAppUserRole
                    //     {
                    //         AppUser = _newUser,
                    //         AppUserRole = item
                    //     });
                    // }

                    // // create
                    // var result = await _userManager.CreateAsync(_newUser, request.RegisterDto.Password);

                    // if (!result.Succeeded) return Result<Unit>.Failure("Problem registering user");

                    // var _tenantSetting = await _context.TenantSettings
                    //     .SingleOrDefaultAsync(x => x.TenantSettingID == Core.Enums.TenantSettings.IsConfirmEmail.GetDescription(), cancellationToken);

                    // var _isConfirmEmail = Core.Helpers.TenantSettings.GetValue<bool>(_tenantSetting.Value);

                    // if (!_isConfirmEmail)
                    //     return Result<Unit>.Success(Unit.Value, "Register successful");

                    // var origin = _httpContextService.GetRequestHeaders("origin");
                    // var token = await _userManager.GenerateEmailConfirmationTokenAsync(_newUser);

                    // token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                    // var verifyUrl = $"{origin}/account/verifyEmail?token={token}&email={_newUser.Email}";
                    // var message = $"<p>Please click the below link to verify your email address:</p><p><a href='{verifyUrl}'>Click to verify email</a></p>";

                    // await _emailSenderService.SendEmailAsync(_newUser.Email, "Please verify email", message);

                    return Result<Unit>.Success(Unit.Value, "Register successful - please verify your email");
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"Failed to register user, Error: {error.Message}");
                    return Result<Unit>.Failure($"Failed to register user: {error.InnerException}");
                }
            }

            private static void CreateUserProfile(Command request, string age, Domain.Tenant.AppUser _newUser)
            {
                var userProfile = new Domain.Tenant.UserProfile
                {
                    AppUser = _newUser,
                    DisplayName = request.RegisterDto.DisplayName,
                    Gender = request.RegisterDto.Gender
                };

                userProfile.Age = age;

                _newUser.UserProfile = userProfile;
            }
        }
    }
}
