using Appointment.Application;
using Appointment.Application.Activities;
using Appointment.Application.Activities.Photos;
using Appointment.Infrastructure.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Appointment.API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { ActivityId = id }));
        }

        //[Authorize(Policy = "IsActivityHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, ActivityDto activityDto)
        {
            activityDto.ActivityId = id;

            return HandleResult(await Mediator.Send(new Edit.Command { ActivityDto = activityDto }));
        }

        //[Authorize(Policy = "IsActivityHost")]
        [HttpPost("{id}/delete")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Application.Activities.Delete.Command { Id = id }));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateActivity(ActivityDto activityDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ActivityDto = activityDto }));
        }

        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command { Id = id }));
        }

        [HttpPost("photos")]
        public async Task<IActionResult> Add([FromForm] Add.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpDelete("photos/{photoId}/{activityId}")]
        public async Task<IActionResult> Delete(string photoId, Guid activityId)
        {
            return HandleResult(await Mediator.Send(new Application.Activities.Photos.Delete.Command { PhotoId = photoId, ActivityId = activityId }));
        }

        [HttpPost("photos/setmain/{photoid}/{activityId}")]
        public async Task<IActionResult> SetMain(string photoId, Guid activityId)
        {
            return HandleResult(await Mediator.Send(new SetMain.Command { PhotoId = photoId, ActivityId = activityId }));
        }
    }
}
