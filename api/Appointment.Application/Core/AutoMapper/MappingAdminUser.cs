using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Application.Core.AutoMapper
{
    public class MappingAdminUser : ProfileBase
    {
        protected override void MapDataTransferObjectToDomain()
        {
            CreateMap<AdminUserDto, Domain.Tenant.AdminUser>();
            CreateMap<CreateAdminUserDto, Domain.Tenant.AdminUser>();
        }

        protected override void MapDomainToDataTransferObject()
        {

        }
    }
}