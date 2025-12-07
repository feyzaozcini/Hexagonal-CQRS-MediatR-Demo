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
    public class RemoveOrderUseCase : IRemoveOrderUseCase
    {
        private readonly IOrderRepository _repository;

        public RemoveOrderUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderCommandResult> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<OrderCommandResult> ExecuteAsync(RemoveOrderCommand command)
        {
            var order = await _repository.GetByIdAsync(command.Id);
            if (order == null)
                throw new NotFoundException("Order not found");

            await _repository.RemoveAsync(order);

            return new OrderCommandResult
            {
                Id = order.Id,
                Message = "Order deleted successfully"
            };
        }
    }

}
