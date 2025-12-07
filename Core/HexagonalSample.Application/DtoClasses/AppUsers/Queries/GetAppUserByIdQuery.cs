using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.AppUsers.Queries
{
    public class GetAppUserByIdQuery : IRequest<GetAppUserQueryResult>
    {
        public int Id { get; set; }
        public GetAppUserByIdQuery(int id) => Id = id;
    }

}
