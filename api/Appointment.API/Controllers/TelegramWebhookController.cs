using Appointment.Application.Telegram;
using Appointment.Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Appointment.API.Controllers
{
    [AllowAnonymous]
    public class TelegramWebhookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TelegramWebhookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Update update)
        {
            return HandleResult(await _mediator.Send(new Updates.Command { Update = update }));
        }

        private ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
                return NotFound();
            if (result.IsSuccess && result.Value != null)
                return Ok(result.Value);
            if (result.IsSuccess && result.Value == null)
                return NotFound();
            if (result.IsUnauthorize && result.Value == null)
                return Unauthorized(result.Error);
            return BadRequest(result.Error);
        }
    }


}
