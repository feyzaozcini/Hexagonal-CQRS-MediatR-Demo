using HexagonalSample.Application.DtoClasses.Orders.Commands;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.OrderPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.OrderUseCases
{
    public class UpdateOrderUseCase : IUpdateOrderUseCase
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderCommandResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<OrderCommandResult> ExecuteAsync(UpdateOrderCommand command)
        {
            var order = await _repository.GetByIdAsync(command.Id);
            if (order == null)
                throw new NotFoundException("Order not found");

            order.ShippingAddress = command.ShippingAddress;
            order.UpdatedDate = DateTime.Now;
            order.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(order);

            return new OrderCommandResult
            {
                Id = order.Id,
                Message = "Order updated successfully"
            };
        }
    }

}
