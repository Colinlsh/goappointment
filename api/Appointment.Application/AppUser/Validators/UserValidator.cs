using Appointment.Infrastructure.Dtos.Api;
using FluentValidation;

namespace Appointment.Application.AppUser
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
        }
    }
}
