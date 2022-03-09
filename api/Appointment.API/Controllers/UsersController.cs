using System;
using System.Threading.Tasks;
using Appointment.Application.AdminUser;
using Appointment.Application.AppUser;
using Appointment.Infrastructure.Constants;
using Appointment.Infrastructure.Controller;
using Appointment.Infrastructure.Dtos.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        [Authorize(Policy = SpecialAuthorization.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            return HandleResult(await Mediator.Send(new Details.Query { UserId = userId }));
        }

        [HttpPost("edit/{userid}")]
        public async Task<IActionResult> EditUser(Guid userId, EditUserDto editUserDto)
        {
            return HandleResult(await Mediator.Send(new Edit.Command { EditUserDto = editUserDto, UserId = userId }));
        }

        [HttpPost("deactivate/{userid}")]
        public async Task<IActionResult> DeactivateUser(Guid userId)
        {
            return HandleResult(await Mediator.Send(new Deactivate.Command { UserId = userId }));
        }

        [HttpPost("activate/{userid}")]
        public async Task<IActionResult> ActivateUser(Guid userId)
        {
            return HandleResult(await Mediator.Send(new Activate.Command { UserId = userId }));
        }

        [HttpDelete("{userid}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { UserId = userId }));
        }

        [HttpPost("admin")]
        public async Task<IActionResult> CreateAdminUser(CreateAdminUserDto createAdminUserDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { CreateAdminUserDto = createAdminUserDto }));
        }
    }
}
