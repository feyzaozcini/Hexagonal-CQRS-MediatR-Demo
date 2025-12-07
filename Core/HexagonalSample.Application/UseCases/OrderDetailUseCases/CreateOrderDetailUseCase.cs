using AutoMapper;
using HexagonalSample.Application.DtoClasses.OrderDetails.Commands;
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
    public class CreateOrderDetailUseCase : ICreateOrderDetailUseCase
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public CreateOrderDetailUseCase(IOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderDetailCommandResult> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<OrderDetailCommandResult> ExecuteAsync(CreateOrderDetailCommand command)
        {
            var detail = _mapper.Map<OrderDetail>(command);
            detail.CreatedDate = DateTime.Now;
            detail.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(detail);

            return new OrderDetailCommandResult
            {
                Id = detail.Id,
                Message = "OrderDetail created successfully"
            };
        }
    }

}
