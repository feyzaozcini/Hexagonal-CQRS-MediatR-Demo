using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.OrderDetails.Commands
{
    public class RemoveOrderDetailCommand : IRequest<OrderDetailCommandResult>
    {
        public int Id { get; set; }
        public RemoveOrderDetailCommand(int id) => Id = id;
    }

}
