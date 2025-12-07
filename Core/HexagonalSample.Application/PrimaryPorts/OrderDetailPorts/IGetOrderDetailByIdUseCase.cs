using HexagonalSample.Application.DtoClasses.OrderDetails.Queires;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.OrderDetailPorts
{
    public interface IGetOrderDetailByIdUseCase: IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailQueryResult>
    {
        Task<GetOrderDetailQueryResult> ExecuteAsync(GetOrderDetailByIdQuery query);
    }
}
