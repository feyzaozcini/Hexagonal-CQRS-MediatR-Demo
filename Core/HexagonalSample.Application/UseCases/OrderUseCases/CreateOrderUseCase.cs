using AutoMapper;
using HexagonalSample.Application.DtoClasses.Orders.Commands;
using HexagonalSample.Application.PrimaryPorts.OrderPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.OrderUseCases
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateOrderUseCase(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<OrderCommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<OrderCommandResult> ExecuteAsync(CreateOrderCommand command)
        {
            Order order = _mapper.Map<Order>(command);
            order.CreatedDate = DateTime.Now;
            order.Status = Domain.Enums.DataStatus.Inserted;

            await _orderRepository.AddAsync(order);

            return new OrderCommandResult
            {
                Id = order.Id,
                Message = "Order created successfully"
            };
        }
    }

}
