using HexagonalSample.Application.DtoClasses.Orders.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.OrderPorts
{
    public interface IGetOrdersUseCase: IRequestHandler<GetOrdersQuery, List<GetOrderQueryResult>>
    {
        Task<List<GetOrderQueryResult>> ExecuteAsync(GetOrdersQuery query);
    }
}
