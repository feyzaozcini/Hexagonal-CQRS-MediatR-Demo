using HexagonalSample.Application.DtoClasses.Orders.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.OrderPorts
{
    public interface IGetOrderByIdUseCase
    : IRequestHandler<GetOrderByIdQuery, GetOrderQueryResult>
    {
        Task<GetOrderQueryResult> ExecuteAsync(GetOrderByIdQuery query);
    }
}
