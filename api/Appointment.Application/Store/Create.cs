using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Dtos.Api;
using Appointment.Persistence;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.Store
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public StoreDto StoreDto { get; set; }
            public Guid CreateBy { get; set; }
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
            private readonly IMapper _mapper;
            private readonly IStoreCommandService _storeCommandService;
            private readonly ILogger<Create> _logger;

            public Handler(AppointmentDataContext context, IMapper mapper, IStoreCommandService storeCommandService, ILogger<Create> logger)
            {
                _context = context;
                _mapper = mapper;
                _storeCommandService = storeCommandService;
                _logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    // check if store name is used or not
                    var newstore = await _context.Store.SingleOrDefaultAsync(x => x.StoreName == request.StoreDto.StoreName, cancellationToken);

                    if (newstore != null)
                        return Result<Unit>.Failure($"{request.StoreDto.StoreName} already exist");

                    var result = await _storeCommandService.CreateStoreAsync(request.CreateBy, request.StoreDto, cancellationToken);

                    if (!result) return Result<Unit>.Failure("Failed to create user");

                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to create store {request.StoreDto.StoreName}", ex);
                    return Result<Unit>.Failure($"Exception: {ex.Message}");
                }
            }
        }

    }
}
