using AutoMapper;

namespace Appointment.Application.Core
{
    public abstract class ProfileBase : Profile
    {
        protected readonly IMapper mapper;
        protected ProfileBase()
        {
            MapDomainToDataTransferObject();

            MapDataTransferObjectToDomain();
        }
        protected abstract void MapDomainToDataTransferObject();
        protected abstract void MapDataTransferObjectToDomain();
    }
}
