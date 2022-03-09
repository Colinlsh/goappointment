using AutoMapper;
using FluentValidation;
using Appointment.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;

namespace Appointment.Application.Activities
{
    public class Create
    {

        public class Command : IRequest<Result<Unit>>
        {
            public ActivityDto ActivityDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IHttpContextService _userAccessor;
            private readonly IMapper _mapper;

            public Handler(AppointmentDataContext context, IHttpContextService userAccessor, IMapper mapper)
            {
                _context = context;
                _userAccessor = userAccessor;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // var user = await _userManager.FindByNameAsync(_userAccessor.GetUsername());

                // var _newActivity = _mapper.Map<Activity>(request.ActivityDto);

                // var attendee = new ActivityAttendee
                // {
                //     AppUser = user,
                //     Activity = _newActivity,
                //     IsHost = true
                // };

                // _newActivity.Attendees.Add(attendee);

                // _context.Activity.Add(_newActivity);

                // var result = await _context.SaveChangesAsync() > 0;

                // if (!result) return Result<Unit>.Failure("Failed to create user");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }

}
