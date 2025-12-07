using AutoMapper;
using HexagonalSample.Application.DtoClasses.Products.Commands;
using HexagonalSample.Application.PrimaryPorts.ProductPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.ProductUseCases
{
    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductUseCase(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<ProductCommandResult> ExecuteAsync(CreateProductCommand command)
        {
            var product = _mapper.Map<Product>(command);
            product.CreatedDate = DateTime.Now;
            product.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(product);

            return new ProductCommandResult
            {
                Id = product.Id,
                Message = "Product created successfully"
            };
        }
    }

}
