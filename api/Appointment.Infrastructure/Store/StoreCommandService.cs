using Appointment.Application.Core.Interfaces;
using Appointment.Domain.Tenant;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Store
{
    public class StoreCommandService : IStoreCommandService
    {
        private readonly AppointmentDataContext context;
        private readonly IMapper mapper;
        private readonly IAppUserRequestService appUserRequestService;

        public StoreCommandService(AppointmentDataContext context, IMapper mapper, IAppUserRequestService appUserRequestService)
        {
            this.context = context;
            this.mapper = mapper;
            this.appUserRequestService = appUserRequestService;
        }

        public async Task<bool> CreateStoreAsync(Guid CreateBy, StoreDto storeDto, CancellationToken cancellationToken)
        {
            // map in store attributes
            var newstore = mapper.Map<Domain.Tenant.Store>(storeDto);
            // assign ID
            newstore.OffDays = new List<StoreOffDays>();
            newstore.SpecialOffDays = new List<StoreSpecialOffs>();

            var storeoffdays = mapper.Map<ICollection<StoreOffDays>>(storeDto.StoreOffDaysDtos)
                                        .Select(x =>
                                        {
                                            x.EffectiveStartDate = DateTime.Now;
                                            x.EffectiveEndDate = DateTime.Parse("2999-12-31 00:00:00");
                                            x.CreateDate = DateTime.Now;
                                            x.CreatedBy = CreateBy;
                                            x.UpdateBy = CreateBy;
                                            x.UpdateDate = DateTime.Now;
                                            return x;
                                        });

            var storespecialoffs = mapper.Map<ICollection<StoreSpecialOffs>>(storeDto.StoreSpecialOffsDtos)
                                            .Select(x =>
                                            {
                                                x.EffectiveStartDate = DateTime.Now;
                                                x.EffectiveEndDate = DateTime.Parse("2999-12-31 00:00:00");
                                                x.CreatedBy = CreateBy;
                                                x.UpdateBy = CreateBy;
                                                x.UpdateDate = DateTime.Now;
                                                return x;
                                            });

            // add join table items
            foreach (var item in storeoffdays)
            {
                newstore.OffDays.Add(item);
            }

            // add join table items
            foreach (var item in storespecialoffs)
            {
                newstore.SpecialOffDays.Add(item);
            }

            await context.Store.AddAsync(newstore, cancellationToken);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> CreateStoreOffDaysCollectionAsync(Guid CreateBy, ICollection<StoreOffDaysDto> storeOffDaysDtos, Guid storeId, CancellationToken cancellationToken)
        {
            var newStoreOffdays = mapper.Map<ICollection<StoreOffDays>>(storeOffDaysDtos)
                                            .Select(x =>
                                            {
                                                x.StoreFK = storeId;
                                                x.EffectiveStartDate = DateTime.Now;
                                                x.EffectiveEndDate = DateTime.Parse("2999-12-31 00:00:00");
                                                x.CreateDate = DateTime.Now;
                                                x.CreatedBy = CreateBy;
                                                x.UpdateBy = CreateBy;
                                                x.UpdateDate = DateTime.Now;
                                                return x;
                                            });

            await context.StoreOffDays.AddRangeAsync(newStoreOffdays, cancellationToken);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> CreateStoreOffDaysAsync(Guid CreateBy, StoreOffDaysDto storeOffDaysDto, Guid storeId, CancellationToken cancellationToken)
        {
            var newStoreOffday = mapper.Map<StoreOffDays>(storeOffDaysDto);
            newStoreOffday.StoreFK = storeId;
            newStoreOffday.EffectiveStartDate = DateTime.Now;
            newStoreOffday.EffectiveEndDate = DateTime.Parse("2999-12-31 00:00:00");
            newStoreOffday.CreateDate = DateTime.Now;
            newStoreOffday.CreatedBy = CreateBy;
            newStoreOffday.UpdateBy = CreateBy;
            newStoreOffday.UpdateDate = DateTime.Now;

            await context.StoreOffDays.AddAsync(newStoreOffday, cancellationToken);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> CreateStoreSpecialOffsCollectionAsync(Guid CreateBy, ICollection<StoreSpecialOffsDto> storeSpecialOffsDtos, Guid storeId, CancellationToken cancellationToken)
        {
            var newStoreOffdays = mapper.Map<ICollection<StoreSpecialOffs>>(storeSpecialOffsDtos)
                                            .Select(x =>
                                            {
                                                x.StoreFK = storeId;
                                                x.EffectiveStartDate = DateTime.Now;
                                                x.EffectiveEndDate = DateTime.Parse("2999-12-31 00:00:00");
                                                x.CreateDate = DateTime.Now;
                                                x.CreatedBy = CreateBy;
                                                x.UpdateBy = CreateBy;
                                                x.UpdateDate = DateTime.Now;
                                                return x;
                                            });

            await context.StoreSpecialOffs.AddRangeAsync(newStoreOffdays, cancellationToken);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> CreateStoreSpecialOffsAsync(Guid CreateBy, StoreSpecialOffsDto storeSpecialOffsDto, Guid storeId, CancellationToken cancellationToken)
        {
            var newStoreOffday = mapper.Map<StoreSpecialOffs>(storeSpecialOffsDto);

            newStoreOffday.StoreFK = storeId;
            newStoreOffday.EffectiveStartDate = DateTime.Now;
            newStoreOffday.EffectiveEndDate = DateTime.Parse("2999-12-31 00:00:00");
            newStoreOffday.CreateDate = DateTime.Now;
            newStoreOffday.CreatedBy = CreateBy;
            newStoreOffday.UpdateBy = CreateBy;
            newStoreOffday.UpdateDate = DateTime.Now;

            await context.StoreSpecialOffs.AddAsync(newStoreOffday, cancellationToken);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
