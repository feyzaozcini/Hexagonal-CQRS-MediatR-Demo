using AutoMapper;
using HexagonalSample.Application.DtoClasses.OrderDetails.Queires;
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
    public class GetOrderDetailByIdUseCase : IGetOrderDetailByIdUseCase
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailByIdUseCase(IOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderDetailQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetOrderDetailQueryResult> ExecuteAsync(GetOrderDetailByIdQuery query)
        {
            var detail = await _repository.GetByIdAsync(query.Id);
            if (detail == null)
                throw new NotFoundException("OrderDetail not found");

            return _mapper.Map<GetOrderDetailQueryResult>(detail);
        }
    }

}
