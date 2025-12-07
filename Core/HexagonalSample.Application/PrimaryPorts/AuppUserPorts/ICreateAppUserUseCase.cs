using HexagonalSample.Application.DtoClasses.AppUsers.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.AuppUserPorts
{
    public interface ICreateAppUserUseCase
    : IRequestHandler<CreateAppUserCommand, AppUserCommandResult>
    {
        Task<AppUserCommandResult> ExecuteAsync(CreateAppUserCommand command);
    }

}
