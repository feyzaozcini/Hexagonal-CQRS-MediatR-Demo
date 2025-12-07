
using HexagonalSample.Application.DtoClasses.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.ProductPorts
{
    public interface IGetProductByIdUseCase : IRequestHandler<GetProductByIdQuery, GetProductQueryResult>
    {
        Task<GetProductQueryResult> ExecuteAsync(GetProductByIdQuery query);
    }
}
