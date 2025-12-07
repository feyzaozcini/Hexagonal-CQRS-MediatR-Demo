using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateCategoryUseCase(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

            _mapper.Map(command, category);
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
