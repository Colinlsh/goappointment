using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Application.Core.AutoMapper
{
    public class MappingAppointment : ProfileBase
    {
        protected override void MapDataTransferObjectToDomain()
        {
            CreateMap<AppointmentDto, Domain.Tenant.Appointment>()
                .ForMember(d => d.CustomerProfiles, o => o.Ignore())
                .ForMember(d => d.TelegramCustomerProfile, o => o.Ignore());
                
            CreateMap<CustomerProfileDto, CustomerProfile>();
            CreateMap<TelegramCustomerProfileDto, TelegramCustomerProfile>();
            //.ForMember(d => d.CustomerProfile, o => o.MapFrom(s => s))
            //.ForMember(d => d.CustomerProfileFK, o => o.MapFrom(s => s.));

        }

        protected override void MapDomainToDataTransferObject()
        {
            CreateMap<CustomerProfile, CustomerProfileDto>();
            CreateMap<TelegramCustomerProfile, TelegramCustomerProfileDto>();
            CreateMap<Domain.Tenant.Appointment, AppointmentDto>();

        }
    }
}
