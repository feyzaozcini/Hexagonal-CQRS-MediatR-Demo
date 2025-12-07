using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Products.Commands
{
    public class RemoveProductCommand : IRequest<ProductCommandResult>
    {
        public int Id { get; set; }
        public RemoveProductCommand(int id) => Id = id;
    }

}
