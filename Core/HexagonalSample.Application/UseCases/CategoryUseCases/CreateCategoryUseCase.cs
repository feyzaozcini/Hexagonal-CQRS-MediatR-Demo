using HexagonalSample.Application.DtoClasses.Categories.Commands;
using HexagonalSample.Application.PrimaryPorts.CategoryPorts;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.CategoryUseCases
{
    public class CreateCategoryUseCase : ICreateCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<CategoryCommandResult> ExecuteAsync(CreateCategoryCommand command)
        {
            var category = new Category
            {
                CategoryName = command.CategoryName,
                Description = command.Description,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted
            };

            await _repository.AddAsync(category);

            return new CategoryCommandResult
            {
                Id = category.Id,
                Message = "Category created successfully"
            };
        }
    }

}
