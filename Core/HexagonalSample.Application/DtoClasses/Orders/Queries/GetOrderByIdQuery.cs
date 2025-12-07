using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<GetOrderQueryResult>
    {
        public int Id { get; set; }
        public GetOrderByIdQuery(int id) => Id = id;
    }

}
