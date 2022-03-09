using Appointment.Infrastructure.Common;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.AppUser
{
    public class VerifyEmail
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Email { get; set; }
            public string Token { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMapper _mapper;

            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // var user = await _usermanager.FindByEmailAsync(request.Email);

                // if (user == null) return Result<Unit>.Unauthorize("No user found");

                // var decodedTokenBytes = WebEncoders.Base64UrlDecode(request.Token);
                // var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);
                // var result = await _usermanager.ConfirmEmailAsync(user, decodedToken);

                // if (!result.Succeeded) return Result<Unit>.Failure("Could not verify email address");

                return Result<Unit>.Success(Unit.Value, "Email verification done! you may now login");
            }
        }
    }
}
