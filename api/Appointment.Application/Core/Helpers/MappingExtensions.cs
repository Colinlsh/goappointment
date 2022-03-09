using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using Appointment.Persistence.Extentions;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace Appointment.Application.Core.Helpers
{
    public static class MappingExtensions
    {
        public static IList<UserDto> MapToUserDto(this IEnumerable<Domain.Tenant.AppUser> users, IMapper mapper, AppointmentMainDataContext mainDataContext, IMemoryCache memoryCache)
        {
            var appUsersProfile = users.Select(x => x.UserProfile);

            var userDtos = mapper.Map<IList<UserDto>>(users);
            var final = mapper.Map(appUsersProfile, userDtos);

            return final.Select(x =>
            {
                var userprofile = appUsersProfile.Single(y => y.Id == x.Id);

                x.Religion = mapper.Map<ReligionDto>(mainDataContext.CTReligion.GetFromCache(memoryCache).SingleOrDefault(z => z.ReligionId == userprofile.ReligionFK));

                x.Country = mapper.Map<CountryDto>(mainDataContext.CTCountry.GetFromCache(memoryCache).SingleOrDefault(z => z.CountryId == userprofile.CountryFK));

                x.Occupation = mapper.Map<OccupationDto>(mainDataContext.CTOccupation.GetFromCache(memoryCache).SingleOrDefault(z => z.OccupationId == userprofile.OccupationFK));

                return x;
            }).ToList();
        }

        public static UserDto MapToUserDto(this Domain.Tenant.AppUser users, IMapper mapper, AppointmentMainDataContext mainDataContext, IMemoryCache memoryCache)
        {
            var userDtos = mapper.Map<UserDto>(users);
            var final = mapper.Map(users.UserProfile, userDtos);

            final.Religion = mapper.Map<ReligionDto>(mainDataContext.CTReligion.GetFromCache(memoryCache).SingleOrDefault(z => z.ReligionId == users.UserProfile.ReligionFK));

            final.Country = mapper.Map<CountryDto>(mainDataContext.CTCountry.GetFromCache(memoryCache).SingleOrDefault(z => z.CountryId == users.UserProfile.CountryFK));

            final.Occupation = mapper.Map<OccupationDto>(mainDataContext.CTOccupation.GetFromCache(memoryCache).SingleOrDefault(z => z.OccupationId == users.UserProfile.OccupationFK));

            return final;
        }
    }
}
