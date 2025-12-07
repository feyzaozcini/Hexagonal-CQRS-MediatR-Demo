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
    public class RemoveProductUseCase : IRemoveProductUseCase
    {
        private readonly IProductRepository _repository;

        public RemoveProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductCommandResult> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<ProductCommandResult> ExecuteAsync(RemoveProductCommand command)
        {
            var product = await _repository.GetByIdAsync(command.Id);
            if (product == null)
                throw new NotFoundException("Product not found");

            await _repository.RemoveAsync(product);

            return new ProductCommandResult
            {
                Id = product.Id,
                Message = "Product deleted successfully"
            };
        }
    }

}
