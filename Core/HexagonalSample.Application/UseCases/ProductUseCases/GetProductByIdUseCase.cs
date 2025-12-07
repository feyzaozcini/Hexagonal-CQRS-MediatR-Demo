using AutoMapper;
using HexagonalSample.Application.DtoClasses.Products.Queries;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.ProductPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.ProductUseCases
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdUseCase(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetProductQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetProductQueryResult> ExecuteAsync(GetProductByIdQuery query)
        {
            var product = await _repository.GetByIdAsync(query.Id);
            if (product == null)
                throw new NotFoundException("Product not found");

            return _mapper.Map<GetProductQueryResult>(product);
        }
    }

}
