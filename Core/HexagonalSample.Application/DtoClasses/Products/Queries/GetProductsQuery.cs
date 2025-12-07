using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Products.Queries
{
    public class GetProductsQuery : IRequest<List<GetProductQueryResult>>
    {
    }

}
