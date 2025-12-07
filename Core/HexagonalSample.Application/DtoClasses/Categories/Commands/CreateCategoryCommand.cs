using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryCommandResult>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
