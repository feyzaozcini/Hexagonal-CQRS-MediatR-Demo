using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Products.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductQueryResult>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id) => Id = id;
    }

}
