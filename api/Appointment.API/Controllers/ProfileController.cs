using Appointment.Application.UserProfile.Photos;
using Appointment.Infrastructure.Constants;
using Appointment.Infrastructure.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetProfileState()
        {
            return HandleResult(await Mediator.Send(new Application.UserProfile.List.Query()));
        }

        //[Authorize(Policy = SpecialAuthorization.SuperAdmin)]
        [HttpGet("religion")]
        public async Task<IActionResult> GetReligion()
        {
            return HandleResult(await Mediator.Send(new Application.UserProfile.Religion.List.Query()));
        }

        [HttpGet("country")]
        public async Task<IActionResult> GetCountry()
        {
            return HandleResult(await Mediator.Send(new Application.UserProfile.Country.List.Query()));
        }

        [HttpGet("occupation")]
        public async Task<IActionResult> GetOccupation()
        {
            return HandleResult(await Mediator.Send(new Application.UserProfile.Occupation.List.Query()));
        }

        [HttpPost("photo")]
        public async Task<IActionResult> Add([FromForm] Add.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpDelete("photo/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { PhotoId = id }));
        }

        [HttpPost("photo/{id}/setmain")]
        public async Task<IActionResult> SetMain(string id)
        {
            return HandleResult(await Mediator.Send(new SetMain.Command { Id = id }));
        }
    }
}
