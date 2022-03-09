using Appointment.Application.Appointment;
using Appointment.Infrastructure.Controller;
using Appointment.Infrastructure.Dtos.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Appointment.API.Controllers
{
    public class AppointmentController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAppointment(AppointmentDto createAppointmentDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { AppointmentDto = createAppointmentDto }));
        }

        [AllowAnonymous]
        [HttpGet("list")]
        public async Task<IActionResult> ListAppointment()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [AllowAnonymous]
        [HttpGet("timeslots/list")]
        public async Task<IActionResult> ListTimeslots(DateTime selectedDate)
        {
            return HandleResult(await Mediator.Send(new ListTimeslots.Query { SelectedDate = selectedDate }));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAppointment(AppointmentDto appointmentDto)
        {
            return HandleResult(await Mediator.Send(new Update.Command { AppointmentDto = appointmentDto }));
        }
    }
}
