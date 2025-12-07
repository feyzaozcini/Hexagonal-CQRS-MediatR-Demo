using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using HexagonalSample.Persistence.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Persistence.EFRepositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyContext context) : base(context)
        {
        }
    }
}
