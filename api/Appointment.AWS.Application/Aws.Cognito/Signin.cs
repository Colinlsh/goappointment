using Appointment.Infrastructure.Aws.Models;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Aws;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Appointment.AWS.Application.Aws.Cognito
{
    public class Signin
    {
        public class Command : IRequest<Result<AwsCognitoAuthReponse>>
        {
            public SigninDto SigninDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<AwsCognitoAuthReponse>>
        {
            private readonly IAwsCognitoCommandService awsCognitoCommandService;

            public Handler(IAwsCognitoCommandService awsCognitoCommandService)
            {
                this.awsCognitoCommandService = awsCognitoCommandService;
            }

            public async Task<Result<AwsCognitoAuthReponse>> Handle(Command request, CancellationToken cancellationToken)
            {

                var response = await awsCognitoCommandService.SignInAsync(request.SigninDto, cancellationToken);

                if (response.HttpStatusCode != System.Net.HttpStatusCode.OK) return Result<AwsCognitoAuthReponse>.Failure("Failed Sign in");

                return Result<AwsCognitoAuthReponse>.Success(new AwsCognitoAuthReponse
                {
                    IdToken = response.AuthenticationResult.IdToken,
                    AccessToken = response.AuthenticationResult.AccessToken,
                    RefreshToken = response.AuthenticationResult.RefreshToken,
                    Type = response.AuthenticationResult.TokenType,
                    ExpiresIn = response.AuthenticationResult.ExpiresIn
                });
            }
        }
    }
}
