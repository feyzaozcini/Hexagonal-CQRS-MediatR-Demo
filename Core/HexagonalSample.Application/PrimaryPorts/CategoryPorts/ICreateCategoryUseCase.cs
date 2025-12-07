using HexagonalSample.Application.DtoClasses.Categories.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.CategoryPorts
{
    public interface ICreateCategoryUseCase: IRequestHandler<CreateCategoryCommand, CategoryCommandResult>
    {
        Task<CategoryCommandResult> ExecuteAsync(CreateCategoryCommand command);
    }

}
