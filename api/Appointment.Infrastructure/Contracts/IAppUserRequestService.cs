using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Appointment.Infrastructure.Dtos.Api;

namespace Appointment.Infrastructure.Contracts
{
    public interface IAppUserRequestService
    {
        Task<Guid> GetAppUserId(string username);
        Task<IList<UserDto>> GetUsers(CancellationToken cancellationToken);
    }
}