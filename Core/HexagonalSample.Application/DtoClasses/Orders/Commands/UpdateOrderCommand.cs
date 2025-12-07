using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<OrderCommandResult>
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
    }

}
