using Appointment.Application.AppUser;
using Appointment.Domain.Enums;
using Appointment.Infrastructure.Controller;
using Appointment.Infrastructure.Dtos.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Appointment.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        private readonly IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            return HandleResult(await Mediator.Send(new Login.Command { LoginDto = loginDto }));
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(string email)
        {
            return HandleResult(await Mediator.Send(new Logout.Command { Email = email }));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
        {
            return HandleResult(await Mediator.Send(new Register.Command { RegisterDto = registerDto }));
        }

        [AllowAnonymous]
        [HttpPost("fbLogin")]
        public async Task<IActionResult> FacebookLogin(string accessToken)
        {
            var fbVerifyingKeys = _config["Facebook:AppId"] + "|" + _config["Facebook:AppSecret"];

            return HandleResult(await Mediator.Send(new ExternalLogin.Query
            {
                LoginType = ExternalLoginType.Facebook,
                AccessToken = accessToken,
                FbVerifyingKeys = fbVerifyingKeys
            }));
        }

        [AllowAnonymous]
        [HttpPost("googleLogin")]
        public async Task<IActionResult> GoogleLogin(string idToken)
        {
            return HandleResult(await Mediator.Send(new ExternalLogin.Query
            {
                LoginType = ExternalLoginType.Google,
                IdToken = idToken
            }));
        }

        [Authorize]
        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            return HandleResult(await Mediator.Send(new RefreshToken.Command()));
        }

        [AllowAnonymous]
        [HttpPost("verifyEmail")]
        public async Task<IActionResult> VerifyEmail(string token, string email)
        {
            return HandleResult(await Mediator.Send(new VerifyEmail.Command { Email = email, Token = token }));
        }

        [AllowAnonymous]
        [HttpGet("resendEmailConfirmationLink")]
        public async Task<IActionResult> ResendEmailConfirmationLink(string email)
        {
            return HandleResult(await Mediator.Send(new ResendEmailConfirmation.Command { Email = email }));
        }
    }
}
