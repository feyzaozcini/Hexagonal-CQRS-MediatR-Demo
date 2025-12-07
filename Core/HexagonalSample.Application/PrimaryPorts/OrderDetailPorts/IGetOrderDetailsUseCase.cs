using HexagonalSample.Application.DtoClasses.OrderDetails.Queires;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.OrderDetailPorts
{
    public interface IGetOrderDetailsUseCase
    : IRequestHandler<GetOrderDetailsQuery, List<GetOrderDetailQueryResult>>
    {
        Task<List<GetOrderDetailQueryResult>> ExecuteAsync(GetOrderDetailsQuery query);
    }
}
