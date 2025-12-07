using AutoMapper;
using HexagonalSample.Application.DtoClasses.Products.Queries;
using HexagonalSample.Application.PrimaryPorts.ProductPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.ProductUseCases
{
    public class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductsUseCase(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetProductQueryResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<List<GetProductQueryResult>> ExecuteAsync(GetProductsQuery query)
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<GetProductQueryResult>>(products);
        }
    }

}
