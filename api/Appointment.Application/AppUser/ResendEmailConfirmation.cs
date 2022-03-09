using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.Application.AppUser
{
    public class ResendEmailConfirmation
    {

        public class Command : IRequest<Result<Unit>>
        {
            public string Email { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IHttpContextService _httpContextService;
            private readonly IEmailSenderService _emailSenderService;

            public Handler(IHttpContextService httpContextService, IEmailSenderService emailSenderService)
            {
                _httpContextService = httpContextService;
                _emailSenderService = emailSenderService;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // var user = await _userManager.FindByEmailAsync(request.Email);

                // if (user == null) return Result<Unit>.Unauthorize("User not found");

                // var origin = _httpContextService.GetRequestHeaders("origin");
                // var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                // token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                // var verifyUrl = $"{origin}/account/verifyEmail?token={token}&email={user.Email}";
                // var message = $"<p>Please click the below link to verify your email address:</p><p><a href='{verifyUrl}'>Click to verify email</a></p>";

                // await _emailSenderService.SendEmailAsync(user.Email, "Please verify email", message);

                return Result<Unit>.Success(Unit.Value, "Email verification sent!");
            }
        }

    }
}
