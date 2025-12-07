using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Orders.Queries
{
    public class GetOrderQueryResult
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
        
    }
}
