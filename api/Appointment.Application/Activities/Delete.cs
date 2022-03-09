using FluentValidation;
using Appointment.Application.Core;
using Appointment.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;

namespace Appointment.Application.Activities
{
    public class Delete
    {

        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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
                var activity = await _context.Activity
                                    .FirstOrDefaultAsync(x => x.ActivityId == request.Id, cancellationToken);

                if (activity != null)
                {
                    var removed = _context.Activity.Remove(activity);

                    var result = await _context.SaveChangesAsync() > 0;

                    return !result ?
                            Result<Unit>.Failure("Failed to delete event") :
                            Result<Unit>.Success(Unit.Value);
                }

                return null;
            }
        }

    }
}
