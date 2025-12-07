using HexagonalSample.Application.DtoClasses.Categories.Queries;
using HexagonalSample.Application.PrimaryPorts.CategoryPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.CategoryUseCases
{
    public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetCategoryQueryResult> ExecuteAsync(GetCategoryByIdQuery query)
        {
            var c = await _repository.GetByIdAsync(query.Id);
            if (c == null)
                throw new Exception("Category not found");

            return new GetCategoryQueryResult
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                Description = c.Description
            };
        }
    }

}
