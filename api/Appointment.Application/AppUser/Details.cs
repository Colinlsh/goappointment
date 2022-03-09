using AutoMapper;
using FluentValidation;
using Appointment.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Application.AppUser
{
    public class Details
    {

        public class Query : IRequest<Result<UserDto>>
        {
            public Guid UserId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Query>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Query, Result<UserDto>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<Details> _logger;

            public Handler(AppointmentDataContext context, IMapper mapper, ILogger<Details> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<UserDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    // var _user = await _userManager.Users
                    //     .Include(u => u.AppUserProfile.ReligionFK)
                    //     .Include(u => u.AppUserProfile.CountryFK)
                    //     .Include(u => u.Activities)
                    //     .Include(u => u.AppUserProfile.Photos)
                    //     .FirstOrDefaultAsync(x => x.Id == request.UserId);

                    // if (_user != null)
                    // {
                    //     var _userdto = _mapper.Map<UserDto>(_user);

                    //     return Result<UserDto>.Success(_userdto);
                    // }

                    // _logger.LogInformation($"User Id: {request.UserId} not found");
                    return Result<UserDto>.Failure(null);
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"Error: {error.Message}");
                    return Result<UserDto>.Failure(null);
                }
            }
        }

    }
}
