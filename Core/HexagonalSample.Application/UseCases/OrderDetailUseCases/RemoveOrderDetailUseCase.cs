using HexagonalSample.Application.DtoClasses.OrderDetails.Commands;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.OrderDetailPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.OrderDetailUseCases
{
    public class RemoveOrderDetailUseCase : IRemoveOrderDetailUseCase
    {
        private readonly IOrderDetailRepository _repository;

        public RemoveOrderDetailUseCase(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderDetailCommandResult> Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<OrderDetailCommandResult> ExecuteAsync(RemoveOrderDetailCommand command)
        {
            var detail = await _repository.GetByIdAsync(command.Id);
            if (detail == null)
                throw new NotFoundException("OrderDetail not found");

            await _repository.RemoveAsync(detail);

            return new OrderDetailCommandResult
            {
                Id = detail.Id,
                Message = "OrderDetail deleted successfully"
            };
        }
    }

}
