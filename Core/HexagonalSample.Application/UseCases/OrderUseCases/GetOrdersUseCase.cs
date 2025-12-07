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
    public class GetOrdersUseCase : IGetOrdersUseCase
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrdersUseCase(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderQueryResult>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<List<GetOrderQueryResult>> ExecuteAsync(GetOrdersQuery query)
        {
            var orders = await _repository.GetAllAsync();
            return _mapper.Map<List<GetOrderQueryResult>>(orders);
        }
    }

}
