using AutoMapper;
using Appointment.Application.Core.Interfaces;
using Appointment.Domain.Enums;
using MediatR;
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
    public class ExternalLogin
    {

        public class Query : IRequest<Result<UserDto>>
        {
            public ExternalLoginType LoginType { get; set; }
            public string AccessToken { get; set; }
            public string IdToken { get; set; }
            public string FbVerifyingKeys { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<UserDto>>
        {
            private readonly IMapper _mapper;
            private readonly AppointmentMainDataContext _mainDataContext;
            private readonly IVerifyExternalLoginService _verifyExternalLogin;
            private readonly ILogger<ExternalLogin> _logger;
            private readonly AppointmentDataContext _context;
            private readonly IMemoryCache _memoryCache;
            private readonly IHttpContextService _httpContextService;

            public Handler(IMapper mapper, AppointmentMainDataContext mainDataContext, IVerifyExternalLoginService verifyExternalLogin, ILogger<ExternalLogin> logger, AppointmentDataContext context, IMemoryCache memoryCache, IHttpContextService httpContextService
                )
            {
                _mapper = mapper;
                _mainDataContext = mainDataContext;
                _verifyExternalLogin = verifyExternalLogin;
                _logger = logger;
                _context = context;
                _memoryCache = memoryCache;
                _httpContextService = httpContextService;
            }

            public async Task<Result<UserDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    // _logger.LogInformation($"External Login: {request.LoginType.GetDescription()}");
                    // switch (request.LoginType)
                    // {
                    //     case ExternalLoginType.Facebook:
                    //         {
                    //             var fbInfo = await _verifyExternalLogin.VerifyFacebookLoginAsync(request.AccessToken, request.FbVerifyingKeys, cancellationToken);

                    //             var username = fbInfo.Name.ToString();
                    //             var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken: cancellationToken);

                    //             if (user != null)
                    //                 return Result<UserDto>.Success(await CreateUserDto(user));

                    //             user = new Domain.Tenant.AppUser
                    //             {
                    //                 Email = fbInfo.Email,
                    //                 UserName = fbInfo.Name.Replace(" ", ""),
                    //             };

                    //             var appUserProfile = new Domain.Tenant.AppUserProfile
                    //             {
                    //                 DisplayName = fbInfo.Name
                    //             };

                    //             await _context.AppUserProfile.AddAsync(appUserProfile, cancellationToken);

                    //             var result2 = await _context.SaveChangesAsync() > 0;

                    //             if (!result2) return Result<UserDto>.Failure($"Failed to create new {request.LoginType.GetDescription()} user: {user.Email}");

                    //             user.EmailConfirmed = true;

                    //             var result = await _userManager.CreateAsync(user);

                    //             if (!result.Succeeded)
                    //             {
                    //                 _logger.LogError($"Failed to create new {request.LoginType.GetDescription()} user: {user.Email}\r\nError: {result.Errors}");
                    //                 return Result<UserDto>.Failure($"error logging in with {request.LoginType.GetDescription()}: {result.Errors}");
                    //             }

                    //             return Result<UserDto>.Success(await CreateUserDto(user));
                    //         }
                    //     case ExternalLoginType.Google:
                    //         {
                    //             var googlePayload = await _verifyExternalLogin.VerifyGoogleLoginAsync(request.IdToken, cancellationToken);

                    //             if (googlePayload == null)
                    //                 return Result<UserDto>.Failure($"Unauthorize");

                    //             var user = await _userManager.FindByEmailAsync(googlePayload.Email);

                    //             if (user != null)
                    //                 return Result<UserDto>.Success(await CreateUserDto (user));

                    //             user = new Domain.Tenant.AppUser
                    //             {
                    //                 Email = googlePayload.Email,
                    //                 UserName = (googlePayload.Name).Replace(" ", ""),
                    //             };

                    //             var appUserProfile = new Domain.Tenant.AppUserProfile
                    //             {
                    //                 DisplayName = googlePayload.Name
                    //             };

                    //             var result2 = await _context.SaveChangesAsync() > 0;

                    //             if (!result2) return Result<UserDto>.Failure($"Failed to create new {request.LoginType.GetDescription()} user: {user.Email}");

                    //             await _context.AppUserProfile.AddAsync(appUserProfile, cancellationToken);

                    //             var result = await _userManager.CreateAsync(user);

                    //             if (!result.Succeeded)
                    //             {
                    //                 _logger.LogError($"Failed to create {request.LoginType.GetDescription()} user: {user.UserName}\r\nError: {result.Errors}");
                    //                 return Result<UserDto>.Failure("Failed to create user");
                    //             }

                    //             return Result<UserDto>.Success(await CreateUserDto(user));
                    //         }
                    //     default:
                    //         return Result<UserDto>.Failure("unknown login type");
                    // }
                    return Result<UserDto>.Failure("unknown login type");
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"{error.Message}");
                    return Result<UserDto>.Failure($"Error: {error.Message}");
                }
            }

            // private async Task<UserDto> CreateUserDto(Domain.Tenant.AppUser user)
            // {
            //     user.ActiveStatus = ActiveStatus.Active.GetDescription();

            //    await user.SetRefreshToken(_tokenService, _userManager, _httpContextService);

            //     var _user = user.MapToUserDto(_mapper, _mainDataContext, _memoryCache);

            //     _user.Token = _tokenService.CreateToken(user);

            //     return _user;
            // }
        }
    }
}
