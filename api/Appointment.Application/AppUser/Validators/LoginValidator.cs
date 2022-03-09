using Appointment.Infrastructure.Dtos.Api;
using FluentValidation;

namespace Appointment.Application.AppUser
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
