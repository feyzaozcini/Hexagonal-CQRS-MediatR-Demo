using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.AppUserProfiles.Queries
{
    public class GetAppUserProfilesQuery : IRequest<List<GetAppUserProfileQueryResult>>
    {
    }

}
