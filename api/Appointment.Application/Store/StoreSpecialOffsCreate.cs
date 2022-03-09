using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Store
{
    public class StoreSpecialOffsCreate
    {

        public class Command : IRequest<Result<Unit>>
        {
            public Guid CreateBy { get; set; }
            public StoreSpecialOffsDto StoreSpecialOffsDto { get; set; }
            public Guid StoreId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IStoreCommandService _storeCommandService;

            public Handler(IStoreCommandService storeCommandService)
            {
                _storeCommandService = storeCommandService;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _storeCommandService.CreateStoreSpecialOffsAsync(request.CreateBy, request.StoreSpecialOffsDto, request.StoreId, cancellationToken);

                if (!result) return Result<Unit>.Failure("Failed to create user");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}
