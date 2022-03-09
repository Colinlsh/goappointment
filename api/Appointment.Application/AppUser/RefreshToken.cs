using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.AppUser
{
    public class RefreshToken
    {

        public class Command : IRequest<Result<UserDto>>
        {
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<UserDto>>
        {
            private readonly AppointmentDataContext _context;
            private readonly AppointmentMainDataContext _mainDataContext;
            private readonly IMemoryCache _memoryCache;
            private readonly IHttpContextService _httpContextService;
            private readonly IMapper _mapper;
            private readonly ILogger<RefreshToken> _logger;

            public Handler(AppointmentDataContext context, AppointmentMainDataContext mainDataContext, IMemoryCache memoryCache, IHttpContextService httpContextService, IMapper mapper, ILogger<RefreshToken> logger)
            {
                _context = context;
                _mainDataContext = mainDataContext;
                _memoryCache = memoryCache;
                _httpContextService = httpContextService;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<UserDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // _logger.LogInformation($"Refreshing token for {_httpContextService.GetUsername()}");
                    // var refreshToken = _httpContextService.GetRefreshToken();
                    // var user = await _userManager.Users
                    //     .Include(r => r.RefreshTokens)
                    //     .Include(u => u.AppUserProfile)
                    //     .FirstOrDefaultAsync(x => x.UserName == _httpContextService.GetUsername(), cancellationToken);

                    // if (user == null)
                    //     return Result<UserDto>.Failure("Failed to refresh token");

                    // var oldToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken);

                    // if (oldToken != null && !oldToken.IsActive)
                    //     return Result<UserDto>.Failure("Failed to refresh token");

                    // var userDto = user.MapToUserDto(_mapper, _mainDataContext, _memoryCache);

                    // userDto.Token = _tokenService.CreateToken(user);

                    return Result<UserDto>.Success(null);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to refresh token: {ex.Message}", ex);
                    return Result<UserDto>.Failure($"Failed to refresh token: {ex.Message}");
                }
            }
        }

    }
}
