using Appointment.Application.UserProfile;
using Appointment.Domain.Tenant;
using AutoMapper;
using System.Linq;

namespace Appointment.Application.Core
{
    public class MappingActivity : ProfileBase
    {
        protected override void MapDataTransferObjectToDomain()
        {
            CreateMap<ActivityDto, Activity>();
        }

        protected override void MapDomainToDataTransferObject()
        {
            // CreateMap<Activity, ActivityDto>()
            //     .ForMember(d => d.HostUsername, o => o.MapFrom(s => s.Attendees
            //         .FirstOrDefault(x => x.IsHost).AppUser.UserName));
            // CreateMap<ActivityAttendee, ProfileDto>()
            //     .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.AppUserProfile.DisplayName))
            //     .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName));
            CreateMap<ActivityPhoto, ActivityPhotoDto>();
        }
    }
}
