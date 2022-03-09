using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Dtos.Api;
using System.Collections.Generic;

namespace Appointment.Application.Core.Interfaces
{
    public interface IServicesRequestService
    {
        IList<Service> GetServices_ByServiceDtoID(IList<ServiceDto> serviceDto);
    }
}