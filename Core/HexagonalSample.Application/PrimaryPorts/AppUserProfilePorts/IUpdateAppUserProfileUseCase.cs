using HexagonalSample.Application.DtoClasses.AppUserProfiles.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.AppUserProfilePorts
{
    public interface IUpdateAppUserProfileUseCase: IRequestHandler<UpdateAppUserProfileCommand, AppUserProfileCommandResult>
    {
        Task<AppUserProfileCommandResult> ExecuteAsync(UpdateAppUserProfileCommand command);
    }

}
