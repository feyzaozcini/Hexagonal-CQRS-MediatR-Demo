using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.OrderDetails.Commands
{
    public class CreateOrderDetailCommand : IRequest<OrderDetailCommandResult>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }

}
