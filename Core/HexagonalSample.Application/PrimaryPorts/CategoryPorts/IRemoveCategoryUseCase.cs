using HexagonalSample.Application.DtoClasses.Categories.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.CategoryPorts
{
    public interface IRemoveCategoryUseCase
    : IRequestHandler<RemoveCategoryCommand, CategoryCommandResult>
    {
        Task<CategoryCommandResult> ExecuteAsync(RemoveCategoryCommand command);
    }

}
