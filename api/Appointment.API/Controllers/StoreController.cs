using Appointment.Application.Store;
using Appointment.Infrastructure.Controller;
using Appointment.Infrastructure.Dtos.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Appointment.API.Controllers
{
    public class StoreController : BaseApiController
    {
        [HttpGet("list")]
        public async Task<IActionResult> List(string hecode)
        {
            return HandleResult(await Mediator.Send(new List.Query { HeCode = hecode }));
        }

        [AllowAnonymous]
        [HttpGet("details")]
        public async Task<IActionResult> Details()
        {
            return HandleResult(await Mediator.Send(new Details.Query()));
        }

        [HttpPost("createstore")]
        public async Task<IActionResult> CreateStore(Guid createBy, StoreDto storeDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { CreateBy = createBy, StoreDto = storeDto }));
        }

        [HttpPost("createstoreoffdays")]
        public async Task<IActionResult> CreateStoreOffDays(Guid createBy, StoreOffDaysDto storeOffDaysDto, Guid storeId)
        {
            return HandleResult(await Mediator.Send(new StoreOffDaysCreate.Command { CreateBy = createBy, StoreOffDaysDto = storeOffDaysDto, StoreId = storeId }));
        }

        [HttpPost("createstorespecialoffs/{storeId}")]
        public async Task<IActionResult> CreateStoreSpecialOffs(Guid createBy, StoreSpecialOffsDto storesSpecialOffsDto, Guid storeId)
        {
            return HandleResult(await Mediator.Send(new StoreSpecialOffsCreate.Command { CreateBy = createBy, StoreSpecialOffsDto = storesSpecialOffsDto, StoreId = storeId }));
        }
    }
}
