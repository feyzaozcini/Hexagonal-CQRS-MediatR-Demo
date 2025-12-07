using HexagonalSample.Application.DtoClasses.Products.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.ProductPorts
{
    public interface IUpdateProductUseCase
    : IRequestHandler<UpdateProductCommand, ProductCommandResult>
    {
        Task<ProductCommandResult> ExecuteAsync(UpdateProductCommand command);
    }
}
