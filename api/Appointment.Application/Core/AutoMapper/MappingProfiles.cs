using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Application.Core
{
    public class MappingProfiles : ProfileBase
    {
        protected override void MapDataTransferObjectToDomain()
        {
            CreateMap<UserDto, Domain.Tenant.AppUser>();
            CreateMap<UserDto, Domain.Tenant.UserProfile>();
            CreateMap<RegisterDto, Domain.Tenant.AppUser>();
            CreateMap<EditUserDto, Domain.Tenant.UserProfile>()
                .ForMember(d => d.ReligionFK, o => o.Ignore())
                .ForMember(d => d.CountryFK, o => o.Ignore())
                .ForMember(d => d.OccupationFK, o => o.Ignore());
        }

        protected override void MapDomainToDataTransferObject()
        {
            CreateMap<Domain.Tenant.AppUser, UserDto>();
            CreateMap<Domain.Tenant.UserProfile, UserDto>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.Username));

            // CreateMap<Domain.Tenant.AppUserRole, AppUserRoleDto>()
            //     .ForMember(d => d.RoleId, o => o.MapFrom(s => s.Id))
            //     .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));

            CreateMap<Domain.Main.CTReligion, ReligionDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ReligionId))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.DisplayValue, o => o.MapFrom(s => s.DisplayValue));
            CreateMap<Domain.Main.CTCountry, CountryDto>()
                .ForMember(d => d.CountryId, o => o.MapFrom(s => s.CountryId))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.DisplayValue, o => o.MapFrom(s => s.DisplayValue));
            CreateMap<Domain.Main.CTOccupation, OccupationDto>()
                .ForMember(d => d.OccupationId, o => o.MapFrom(s => s.OccupationId))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.DisplayValue, o => o.MapFrom(s => s.DisplayValue));
            CreateMap<Domain.Tenant.AppUserPhoto, AppUserPhotoDto>();
        }
    }
}
