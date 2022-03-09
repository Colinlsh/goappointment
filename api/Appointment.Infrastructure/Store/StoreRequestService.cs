using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using Appointment.Persistence.Schema;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Store
{
    public class StoreRequestService : IStoreRequestService
    {
        private readonly AppointmentDataContext context;
        private readonly AppointmentMainDataContext mainDataContext;
        private readonly IMapper mapper;
        private readonly ITenantAccessor tenantAccessor;
        private readonly IMemoryCache memoryCache;

        public StoreRequestService(AppointmentDataContext context, AppointmentMainDataContext mainDataContext, IMapper mapper, ITenantAccessor tenantAccessor, IMemoryCache memoryCache)
        {
            this.context = context;
            this.mainDataContext = mainDataContext;
            this.mapper = mapper;
            this.tenantAccessor = tenantAccessor;
            this.memoryCache = memoryCache;
        }

        public async Task<IList<StoreDto>> GetStoresAsync(CancellationToken cancellationToken)
        {
            var stores = await context.Store
                            .Include(x => x.SpecialOffDays)
                            .Include(x => x.OffDays)
                            .ToListAsync(cancellationToken);

            return stores.Select(x =>
                                    {
                                        var storeoffdaysdtos = mapper.Map<IList<StoreOffDaysDto>>(x.OffDays);
                                        var storespecialoddsdtos = mapper.Map<IList<StoreSpecialOffsDto>>(x.SpecialOffDays);
                                        var storedto = mapper.Map<StoreDto>(x);

                                        storedto.StoreOffDaysDtos = storeoffdaysdtos;
                                        storedto.StoreSpecialOffsDtos = storespecialoddsdtos;

                                        return storedto;
                                    })
                                    .ToList();
        }

        public async Task<StoreDto> GetStoreAsync(CancellationToken cancellationToken)
        {
            var stores = await context.Store
                                .Include(x => x.SpecialOffDays)
                                .Include(x => x.OffDays)
                                .ToListAsync(cancellationToken);

            return stores.Select(x =>
            {
                var storeoffdaysdtos = mapper.Map<IList<StoreOffDaysDto>>(x.OffDays);
                var storespecialoddsdtos = mapper.Map<IList<StoreSpecialOffsDto>>(x.SpecialOffDays);
                var storedto = mapper.Map<StoreDto>(x);

                storedto.StoreOffDaysDtos = storeoffdaysdtos;
                storedto.StoreSpecialOffsDtos = storespecialoddsdtos;

                return storedto;
            }).FirstOrDefault();
        }
    }
}
