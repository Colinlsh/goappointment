using Appointment.Application.Dashboard.Dtos;
using Appointment.Infrastructure.Common;
using Appointment.Persistence;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Dashboard
{
    public class Register
    {
        public class Command : IRequest<Result<Unit>>
        {
            public DashboardRegisterDto RegisterDto { get; set; }
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

            public Handler(AppointmentDataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create user");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}
