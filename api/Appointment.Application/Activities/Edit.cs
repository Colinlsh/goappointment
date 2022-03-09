using AutoMapper;
using FluentValidation;
using Appointment.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;

namespace Appointment.Application.Activities
{
    public class Edit
    {

        public class Command : IRequest<Result<Unit>>
        {
            public ActivityDto ActivityDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ActivityDto.Title).NotEmpty();
                RuleFor(x => x.ActivityDto.Description).NotEmpty();
                RuleFor(x => x.ActivityDto.Category).NotEmpty();
                RuleFor(x => x.ActivityDto.Date).NotEmpty();
                RuleFor(x => x.ActivityDto.City).NotEmpty();
                RuleFor(x => x.ActivityDto.Venue).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppointmentDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppointmentDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activity.FindAsync(request.ActivityDto.ActivityId);

                _mapper.Map(request.ActivityDto,activity);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit activity");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}
