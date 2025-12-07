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
    public class RemoveCategoryUseCase : IRemoveCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryCommandResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<CategoryCommandResult> ExecuteAsync(RemoveCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);
            if (category == null)
                throw new NotFoundException("Category not found");

            await _repository.RemoveAsync(category);

            return new CategoryCommandResult
            {
                Id = command.Id,
                Message = "Category deleted successfully"
            };
        }
    }

}
