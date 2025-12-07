using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.AppUserProfiles.Queries
{
    public class GetAppUserProfileByIdQuery : IRequest<GetAppUserProfileQueryResult>
    {
        public int Id { get; set; }
        public GetAppUserProfileByIdQuery(int id) => Id = id;
    }

}
