using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Orders.Commands
{
    public class CreateOrderCommand : IRequest<OrderCommandResult>
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
