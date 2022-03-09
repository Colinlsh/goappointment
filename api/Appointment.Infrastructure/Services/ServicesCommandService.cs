using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Services
{
    public class ServicesCommandService : IServicesCommandService
    {
        private readonly AppointmentDataContext context;
        private readonly IMapper mapper;

        public ServicesCommandService(AppointmentDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> EditService(ServiceDto serviceDto, CancellationToken cancellationToken)
        {
            var service = await context.Service
                    .Include(s => s.ServiceItems).ThenInclude(s => s.ServiceItem)
                    .FirstOrDefaultAsync(x => x.Id == serviceDto.Id, cancellationToken);

            // check if serviceitem belongs to current service or not, edition of service items will not be done here. only addition or removal.
            var serviceServiceItems = await context.ServiceServiceItem
                .Where(x => x.ServiceFK == service.Id)
                .ToListAsync(cancellationToken);
            var serviceItems = await context.ServiceItem.ToListAsync(cancellationToken);

            var _toAddServiceItems = serviceDto.ServiceItemDtos
                .ToList()
                .FindAll(x => !serviceServiceItems.Any(z => z.ServiceItemFK == x.Id))
                .Select(sidto =>
                {
                    var serviceItem = serviceItems.FirstOrDefault(x => x.Id == sidto.Id);

                    return new ServiceServiceItem { Service = service, ServiceItem = serviceItem };
                });

            var _toRemoveServiceServiceItems = serviceServiceItems
                .Where(x => serviceDto.ServiceItemDtos.Select(ssi => ssi.Id == x.ServiceItemFK).FirstOrDefault());

            // remove if not found in service service item
            if (_toRemoveServiceServiceItems.Any())
                context.ServiceServiceItem.RemoveRange(_toRemoveServiceServiceItems);
            // add new service service items
            foreach (var item in _toAddServiceItems)
            {
                context.Entry(item).State = EntityState.Unchanged;
                context.ServiceServiceItem.Add(item);
            }

            var _newService = mapper.Map(serviceDto, service);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
