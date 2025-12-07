using HexagonalSample.Application.DtoClasses.Categories.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.PrimaryPorts.CategoryPorts
{
    public interface IGetCategoryByIdUseCase: IRequestHandler<GetCategoryByIdQuery, GetCategoryQueryResult>
    {
        Task<GetCategoryQueryResult> ExecuteAsync(GetCategoryByIdQuery query);
    }

}
