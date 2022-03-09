using Appointment.Infrastructure.Dtos.Api;
using FluentValidation;

namespace Appointment.Application.AppUser.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty();
                //.Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")
                //.WithMessage("Password did meet requirement: Minimum eight characters, at least one letter and one number");
        }
    }
}
