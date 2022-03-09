using AutoMapper;
using Appointment.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Infrastructure.Contracts;

namespace Appointment.Application.AppUser
{
    public class Login
    {
        public class Command : IRequest<Result<UserDto>>
        {
            public LoginDto LoginDto { get; set; }
        }

        public class CommandValidator : LoginValidator
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<UserDto>>
        {
            private readonly IMemoryCache _memoryCache;
            private readonly AppointmentDataContext _context;
            private readonly AppointmentMainDataContext _mainDataContext;
            private readonly IMapper _mapper;
            private readonly ILogger<Login> _logger;
            private readonly IHttpContextService _httpContextService;

            public Handler(AppointmentDataContext context, AppointmentMainDataContext mainDataContext, IMemoryCache memoryCache, IMapper mapper, ILogger<Login> logger, IHttpContextService httpContextService)
            {
                _memoryCache = memoryCache;
                _context = context;
                _mainDataContext = mainDataContext;
                _mapper = mapper;
                _logger = logger;
                _httpContextService = httpContextService;
            }

            public async Task<Result<UserDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // var user = await _userManager.Users
                    //     .Include(u => u.AppUserProfile.Photos)
                    //     .Include(u => u.RefreshTokens)
                    //     .FirstOrDefaultAsync(x => x.Email == request.LoginDto.Email, cancellationToken);

                    // if (user == null)
                    // {
                    //     _logger.LogInformation($"{request.LoginDto.Email} user not found");
                    //     return Result<UserDto>.Unauthorize($"{request.LoginDto.Email} user not found");
                    // }

                    // if (user.UserName == "Colin88888888" || user.UserName == "JaneJane") user.EmailConfirmed = true;

                    // if (!user.EmailConfirmed) return Result<UserDto>.Unauthorize("Email not confirmed");

                    // var result = await _signInManager.CheckPasswordSignInAsync(user, request.LoginDto.Password, false);

                    // if (!result.Succeeded)
                    // {
                    //     _logger.LogError($"Wrong password: {user.UserName}");
                    //     return Result<UserDto>.Failure($"Wrong password: {user.UserName}");
                    // }

                    // var _loggedinUser = await _userManager.Users
                    //             .SingleOrDefaultAsync(x => x.Id == user.Id, cancellationToken);

                    // await _loggedinUser.SetRefreshToken(_tokenService, _userManager, _httpContextService);

                    // var userDto = _loggedinUser.MapToUserDto(_mapper, _mainDataContext, _memoryCache);

                    // userDto.Token = _tokenService.CreateToken(user);

                    return Result<UserDto>.Success(null);
                }
                catch (Exception error)
                {
                    _logger.LogCritical(error, $"Exception: {error.Message}");
                    return Result<UserDto>.Failure($"Failed to login user: {error.Message}");
                }
            }
        }

    }
}
