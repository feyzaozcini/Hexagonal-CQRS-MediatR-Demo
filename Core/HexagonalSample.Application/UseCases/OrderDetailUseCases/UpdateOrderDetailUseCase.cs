using AutoMapper;
using HexagonalSample.Application.DtoClasses.OrderDetails.Commands;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.OrderDetailPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.OrderDetailUseCases
{
    public class UpdateOrderDetailUseCase : IUpdateOrderDetailUseCase
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public UpdateOrderDetailUseCase(IOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderDetailCommandResult> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<OrderDetailCommandResult> ExecuteAsync(UpdateOrderDetailCommand command)
        {
            var detail = await _repository.GetByIdAsync(command.Id);
            if (detail == null)
                throw new NotFoundException("OrderDetail not found");

            _mapper.Map(command, detail);
            detail.UpdatedDate = DateTime.Now;
            detail.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(detail);

            return new OrderDetailCommandResult
            {
                Id = detail.Id,
                Message = "OrderDetail updated successfully"
            };
        }
    }

}
