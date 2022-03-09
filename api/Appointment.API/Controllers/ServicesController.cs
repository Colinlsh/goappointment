using Appointment.Application.Service;
using Appointment.Infrastructure.Controller;
using Appointment.Infrastructure.Dtos.Api;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Appointment.API.Controllers
{
    public class ServicesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateService(ServiceDto serviceDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ServiceDto = serviceDto }));
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditService(ServiceDto serviceDto)
        {
            return HandleResult(await Mediator.Send(new Edit.Command { ServiceDto = serviceDto }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteService(Guid serviceId)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { ServiceId = serviceId }));
        }

        [HttpPost("serviceitem/create")]
        public async Task<IActionResult> CreateServiceItem(ServiceItemDto serviceItemDto)
        {
            return HandleResult(await Mediator.Send(new ServiceItemCreate.Command { ServiceItemDto = serviceItemDto }));
        }

        [HttpGet("serviceitem/")]
        public async Task<IActionResult> GetServiceItems()
        {
            return HandleResult(await Mediator.Send(new ServiceItemList.Query()));
        }

        [HttpPost("serviceitem/edit")]
        public async Task<IActionResult> EditServiceItem(ServiceItemDto serviceItemDto)
        {
            return HandleResult(await Mediator.Send(new ServiceItemEdit.Command { ServiceItemDto = serviceItemDto }));
        }

        [HttpDelete("serviceitem")]
        public async Task<IActionResult> DeleteServiceItem(Guid serviceItemId)
        {
            return HandleResult(await Mediator.Send(new ServiceItemDelete.Command { ServiceItemId = serviceItemId }));
        }
    }
}
