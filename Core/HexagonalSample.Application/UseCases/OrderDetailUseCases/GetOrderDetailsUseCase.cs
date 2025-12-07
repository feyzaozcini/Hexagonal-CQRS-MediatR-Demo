using AutoMapper;
using HexagonalSample.Application.DtoClasses.OrderDetails.Queires;
using HexagonalSample.Application.PrimaryPorts.OrderDetailPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.OrderDetailUseCases
{
    public class GetOrderDetailsUseCase : IGetOrderDetailsUseCase
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailsUseCase(IOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<List<GetOrderDetailQueryResult>> ExecuteAsync(GetOrderDetailsQuery query)
        {
            var details = await _repository.GetAllAsync();
            return _mapper.Map<List<GetOrderDetailQueryResult>>(details);
        }
    }

}
