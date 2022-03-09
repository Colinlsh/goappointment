using Appointment.AWS.Application.Aws.Cognito;
using Appointment.Infrastructure.Controller;
using Appointment.Infrastructure.Dtos.Aws;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Appointment.API.AWS.Cognito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSCognitoController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(SigninDto signinDto)
        {
            return HandleResult(await Mediator.Send(new Signin.Command { SigninDto = signinDto }));
        }
    }
}
