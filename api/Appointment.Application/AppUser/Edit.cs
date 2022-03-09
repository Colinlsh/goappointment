using AutoMapper;
using FluentValidation;
using Appointment.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Application.AppUser
{
    public class Edit
    {
        public class Command : IRequest<Result<UserDto>>
        {
            public Guid UserId { get; set; }
            public EditUserDto EditUserDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<UserDto>>
        {
            private readonly AppointmentMainDataContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<Edit> _logger;
            private readonly IMemoryCache _memoryCache;

            public Handler(AppointmentMainDataContext context, IMapper mapper, ILogger<Edit> logger, IMemoryCache memoryCache)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
                _memoryCache = memoryCache;
            }

            public async Task<Result<UserDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // var user = await _userManager.Users
                    //             .Include(u => u.AppUserProfile)
                    //             .SingleOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

                    // if (user != null)
                    // {
                    //     // look for the correct religion object for assignment
                    //     var religion = _context.CTReligion
                    //                             .GetFromCache(_memoryCache)
                    //                             .Find(x => x.ReligionId == request.EditUserDto.Religion.Id);
                    //     var country = _context.CTCountry
                    //                             .GetFromCache(_memoryCache)
                    //                             .Find(x => x.CountryId == request.EditUserDto.Country.CountryId);
                    //     var occupation = await CheckOccupationAvailability(request, cancellationToken);

                    //     user = _mapper.Map(request.EditUserDto, user);

                    //     user.AppUserProfile.ReligionFK = religion.ReligionId;
                    //     user.AppUserProfile.CountryFK = country.CountryId;
                    //     user.AppUserProfile.OccupationFK = occupation.OccupationId;

                    //     // update date
                    //     user.UpdateDate = DateTime.Now;

                    //     var result = await _userManager.UpdateAsync(user);

                    //     if (!result.Succeeded)
                    //     {
                    //         _logger.LogError($"Failed to update profile: {result.Errors}");
                    //         return Result<UserDto>.Failure("Failed to update profile");
                    //     }

                    //     return Result<UserDto>.Success(_mapper.Map<UserDto>(user));
                    // }

                    // _logger.LogInformation($"User: {request.EditUserDto.Email} not found");
                    return Result<UserDto>.Failure("No user found");
                }
                catch (Exception error)
                {
                    _logger.LogError(error, $"Error: {error.Message}");
                    return Result<UserDto>.Failure($"Error: {error}");
                }
            }

            private async Task<Domain.Main.CTOccupation> CheckOccupationAvailability(Command request, CancellationToken cancellationToken)
            {
                var occupation = await _context.CTOccupation.SingleOrDefaultAsync(x =>
                x.OccupationId == request.EditUserDto.Occupation.OccupationId &&
                x.DisplayValue == request.EditUserDto.Occupation.DisplayValue, cancellationToken);

                if (occupation != null)
                    return occupation;

                var newOccupation = new Domain.Main.CTOccupation
                {
                    OccupationId = request.EditUserDto.Occupation.OccupationId,
                    Description = request.EditUserDto.Occupation.Description.ToLower(),
                    DisplayValue = request.EditUserDto.Occupation.DisplayValue.ToLower(),
                    IsUserMaintainable = false,
                    SortOrder = await _context.CTOccupation.CountAsync() + 1,
                    EffectiveStartDate = DateTime.Now,
                    EffectiveEndDate = DateTime.Parse("2999-12-31 00:00:00"),
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                };

                await _context.CTOccupation.AddAsync(newOccupation, cancellationToken);

                return newOccupation;
            }
        }
    }
}
