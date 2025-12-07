using HexagonalSample.Application.DtoClasses.AppUserProfiles.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.AppUserProfilePorts
{
    public interface IGetAppUserProfilesUseCase
    : IRequestHandler<GetAppUserProfilesQuery, List<GetAppUserProfileQueryResult>>
    {
        Task<List<GetAppUserProfileQueryResult>> ExecuteAsync(GetAppUserProfilesQuery query);
    }

}
