using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Appointment.Persistence;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Caching.Memory;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Infrastructure.Contracts;

namespace Appointment.Application.AppUser
{
    public class List
    {
        public class Query : IRequest<Result<IList<UserDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<IList<UserDto>>>
        {
            private readonly IAppUserRequestService appUserRequestService;
            private readonly ILogger<List> logger;

            public Handler(IAppUserRequestService appUserRequestService, ILogger<List> logger)
            {
                this.logger = logger;
                this.appUserRequestService = appUserRequestService;

            }

            public async Task<Result<IList<UserDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                //var userDtos = _context.Users
                //    .Where(x => x.Status == Status.Active.GetDescription())
                //    .Join(_context.Religion,
                //        user => user.ReligionFK,
                //        religion => religion.ReligionId,
                //        (user, religion) => new
                //        {
                //            user,
                //            religion
                //        })
                //    .Join(_context.Country,
                //    re => re.user.CountryFK,
                //    country => country.CountryId,
                //    (re, country) => new UserDto
                //    {
                //        UserId = re.user.UserId,
                //        FirstName = re.user.FirstName,
                //        LastName = re.user.LastName,
                //        Title = re.user.Title,
                //        Gender = re.user.Gender,
                //        Religion = re.religion.DisplayValue,
                //        Country = country.DisplayValue,
                //        Age = re.user.Age,
                //        PhoneNumber = re.user.PhoneNumber
                //    }).ToList();

                // inner join
                //var userDtos = await (from user in _context.Users
                //            join religion in _context.Religion 
                //                on user.ReligionFK equals religion.ReligionId
                //            join country in _context.Country 
                //                on user.CountryFK equals country.CountryId
                //            where user.Status == Status.Active.GetDescription()
                //            select new UserDto
                //            {
                //                UserId = user.UserId,
                //                FirstName = user.FirstName,
                //                LastName = user.LastName,
                //                Title = user.Title,
                //                Gender = user.Gender,
                //                Religion = religion.DisplayValue,
                //                Country = country.DisplayValue,
                //                Age = user.Age,
                //                PhoneNumber = user.PhoneNumber
                //            })
                //            .ToListAsync();

                // left join

                // manual mapping
                //var userDtos = await (from user in _userManager.Users
                //                      from religion in _context.Religions
                //                        .Where(religion => religion == user.Religion).DefaultIfEmpty()
                //                      from country in _context.Countries
                //                        .Where(country => country.CountryId == user.Country.CountryId).DefaultIfEmpty()
                //                      where user.ActiveStatus == ActiveStatus.Active.GetDescription()
                //                      select new UserDto
                //                      {
                //                          Title = user.Title,
                //                          DisplayName = user.DisplayName,
                //                          UserName = user.UserName,
                //                          Gender = user.Gender,
                //                          Religion = religion.DisplayValue,
                //                          Country = country.DisplayValue,
                //                          Age = user.Age,
                //                          PhoneNumber = user.PhoneNumber
                //                      })
                //           .ToListAsync();

                // eager loading
                try
                {
                    // var users = await _userManager.Users
                    // .Include(u => u.AppUserProfile)
                    // .Include(u => u.AppUserRoles).ThenInclude(u => u.AppUserRole)
                    // .ToListAsync(cancellationToken);

                    // // map fk to common table
                    // var userDtos = users.MapToUserDto(_mapper, _mainContext, _memoryCache);

                    var users = await appUserRequestService.GetUsers(cancellationToken);

                    return Result<IList<UserDto>>.Success(null);
                }
                catch (Exception error)
                {
                    logger.LogError(error, $"Failed to list users: {error.Message}");
                    return Result<IList<UserDto>>.Failure($"{error.Message}");
                }
            }
        }

    }
}
