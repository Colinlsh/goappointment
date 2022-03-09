using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Application.Core.AutoMapper
{
    public class MappingStore : ProfileBase
    {
        protected override void MapDataTransferObjectToDomain()
        {
            CreateMap<StoreDto, Domain.Tenant.Store>();
            CreateMap<StoreOffDaysDto, StoreOffDays>();
            CreateMap<StoreSpecialOffsDto, StoreSpecialOffs>();
        }

        protected override void MapDomainToDataTransferObject()
        {
            CreateMap<Domain.Tenant.Store, StoreDto>()
                .ForMember(d => d.StoreOffDaysDtos, o => o.Ignore())
                .ForMember(d => d.StoreSpecialOffsDtos, o => o.Ignore());
            CreateMap<StoreOffDays, StoreOffDaysDto>();
            CreateMap<StoreSpecialOffs, StoreSpecialOffsDto>();
        }
    }
}
