using HexagonalSample.Application.DtoClasses.OrderDetails.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.OrderDetailPorts
{
    public interface IUpdateOrderDetailUseCase
    : IRequestHandler<UpdateOrderDetailCommand, OrderDetailCommandResult>
    {
        Task<OrderDetailCommandResult> ExecuteAsync(UpdateOrderDetailCommand command);
    }
}
