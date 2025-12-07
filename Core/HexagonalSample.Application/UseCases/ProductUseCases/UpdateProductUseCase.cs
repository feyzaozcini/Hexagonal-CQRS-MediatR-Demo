using AutoMapper;
using HexagonalSample.Application.DtoClasses.Products.Commands;
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
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductUseCase(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCommandResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<ProductCommandResult> ExecuteAsync(UpdateProductCommand command)
        {
            var product = await _repository.GetByIdAsync(command.Id);
            if (product == null)
                throw new NotFoundException("Product not found");

            _mapper.Map(command, product);
            product.UpdatedDate = DateTime.Now;
            product.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(product);

            return new ProductCommandResult
            {
                Id = product.Id,
                Message = "Product updated successfully"
            };
        }
    }

}
