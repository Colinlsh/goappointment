using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Application.Core.AutoMapper
{
    public class MappingService : ProfileBase
    {
        protected override void MapDataTransferObjectToDomain()
        {
            CreateMap<ServiceItemDto, Domain.Tenant.ServiceItem>();
            CreateMap<ServiceDto, Domain.Tenant.Service>();
        }

        protected override void MapDomainToDataTransferObject()
        {
            CreateMap<Domain.Tenant.Service, ServiceDto>();
            CreateMap<Domain.Tenant.ServiceItem, ServiceItemDto>();

            CreateMap<Domain.Tenant.ServiceServiceItem, ServiceItemDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ServiceItem.Id))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.ServiceItem.Title))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.ServiceItem.Description))
                .ForMember(d => d.DurationHour, o => o.MapFrom(s => s.ServiceItem.DurationHour))
                .ForMember(d => d.DurationMinutes, o => o.MapFrom(s => s.ServiceItem.DurationMinutes));
        }
    }
}
