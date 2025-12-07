using AutoMapper;
using HexagonalSample.Application.DtoClasses.Orders.Queries;
using HexagonalSample.Application.PrimaryPorts.OrderPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.OrderUseCases
{
    public class GetOrderByIdUseCase : IGetOrderByIdUseCase
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderByIdUseCase(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetOrderQueryResult> ExecuteAsync(GetOrderByIdQuery query)
        {
            var order = await _repository.GetByIdAsync(query.Id);
            if (order == null)
                throw new Exception("Order not found");

            return _mapper.Map<GetOrderQueryResult>(order);
        }
    }

}
