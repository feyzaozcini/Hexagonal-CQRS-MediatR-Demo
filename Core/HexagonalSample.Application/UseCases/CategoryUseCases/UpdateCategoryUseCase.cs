using HexagonalSample.Application.DtoClasses.Categories.Commands;
using HexagonalSample.Application.Exceptions;
using HexagonalSample.Application.PrimaryPorts.CategoryPorts;
using HexagonalSample.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.CategoryUseCases
{
    public class UpdateCategoryUseCase : IUpdateCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryCommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<CategoryCommandResult> ExecuteAsync(UpdateCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);
            if (category == null)
                throw new NotFoundException("Category not found");

            category.CategoryName = command.CategoryName;
            category.Description = command.Description;
            category.UpdatedDate = DateTime.Now;
            category.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(category);

            return new CategoryCommandResult
            {
                Id = category.Id,
                Message = "Category updated successfully"
            };
        }
    }

}
