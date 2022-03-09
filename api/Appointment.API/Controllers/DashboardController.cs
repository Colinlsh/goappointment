using Appointment.Application.Dashboard;
using Appointment.Application.Dashboard.Dtos;
using Appointment.Application.Dashboard.OffBoarding;
using Appointment.Application.Dashboard.Onboarding;
using Appointment.Infrastructure.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Appointment.API.Controllers
{
    //[Authorize]
    //[Authorize(Policy = SpecialAuthorization.IsSuperAdmin)]
    [Route("api/[controller]")]
    public class DashboardController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(DashboardLoginDto dashboardLoginDto)
        {
            return HandleResult(await Mediator.Send(new Login.Command { DashboardLoginDto = dashboardLoginDto }));
        }

        [HttpPost("addtenantmapping")]
        public async Task<IActionResult> AddTenantMapping(string tenantCode)
        {
            return HandleResult(await Mediator.Send(new AddTenantMapping.Command { TenantCode = tenantCode }));
        }

        [AllowAnonymous]
        [HttpPost("addtenant")]
        public async Task<IActionResult> AddTenant(string heCode)
        {
            return HandleResult(await Mediator.Send(new AddTenant.Command { HeCode = heCode }));
        }

        [HttpPost("applymigrations")]
        public async Task<IActionResult> Applymigrations(string heCode)
        {
            return HandleResult(await Mediator.Send(new ApplyMigrations.Command { HeCode = heCode }));
        }

        [HttpPost("rollbackpreviousmigration")]
        public async Task<IActionResult> RollbackPreviousMigration(string heCode)
        {
            return HandleResult(await Mediator.Send(new RollbackPreviousMigration.Command { HeCode = heCode }));
        }

        [HttpDelete("deletetenant")]
        public async Task<IActionResult> DeleteTenant(string heCode)
        {
            return HandleResult(await Mediator.Send(new DeleteTenant.Command { HeCode = heCode }));
        }
    }
}
