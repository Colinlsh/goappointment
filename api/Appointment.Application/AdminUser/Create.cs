using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Common;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Dtos.Api;
using FluentValidation;
using MediatR;

namespace Appointment.Application.AdminUser
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateAdminUserDto CreateAdminUserDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IAwsApiCommandService awsApiCommandService;
            private readonly IAdminUserCommandService adminUserCommandService;

            public Handler(IAwsApiCommandService awsApiCommandService, IAdminUserCommandService adminUserCommandService)
            {
                this.awsApiCommandService = awsApiCommandService;
                this.adminUserCommandService = adminUserCommandService;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await awsApiCommandService.CreateAdminUserAsync(request.CreateAdminUserDto, cancellationToken);

                    if (result.HttpStatusCode != HttpStatusCode.OK)
                        return Result<Unit>.Failure($"{result.ResponseMetadata.Metadata}");

                    var id = result.User.Attributes.FirstOrDefault(x => x.Name == "sub").Value;

                    if (!Guid.TryParse(id, out Guid idresult))
                        throw new Exception("wrong id format");

                    request.CreateAdminUserDto.Id = idresult;

                    await adminUserCommandService.CreateAdminUserAsync(request.CreateAdminUserDto, cancellationToken);

                    return Result<Unit>.Success(Unit.Value);
                }
                catch (Exception ex)
                {
                    return Result<Unit>.Failure($"{ex.Message}");
                }
            }
        }
    }
}