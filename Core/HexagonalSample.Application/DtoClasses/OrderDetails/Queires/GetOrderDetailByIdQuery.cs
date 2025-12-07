using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.OrderDetails.Queires
{
    public class GetOrderDetailByIdQuery : IRequest<GetOrderDetailQueryResult>
    {
        public int Id { get; set; }
        public GetOrderDetailByIdQuery(int id) => Id = id;
    }

}
