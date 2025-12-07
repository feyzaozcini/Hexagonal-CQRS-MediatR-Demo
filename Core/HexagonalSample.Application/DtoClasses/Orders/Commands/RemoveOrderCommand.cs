using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Orders.Commands
{
    public class RemoveOrderCommand : IRequest<OrderCommandResult>
    {
        public int Id { get; set; }
        public RemoveOrderCommand(int id) => Id = id;
    }

}
