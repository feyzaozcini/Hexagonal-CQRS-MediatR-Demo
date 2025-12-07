using HexagonalSample.Application.DtoClasses.Orders.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.OrderPorts
{
    public interface IUpdateOrderUseCase: IRequestHandler<UpdateOrderCommand, OrderCommandResult>
    {
        Task<OrderCommandResult> ExecuteAsync(UpdateOrderCommand command);
    }
}
