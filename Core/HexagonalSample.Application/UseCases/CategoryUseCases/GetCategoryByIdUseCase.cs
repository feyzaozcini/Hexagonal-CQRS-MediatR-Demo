using AutoMapper;
using HexagonalSample.Application.DtoClasses.Categories.Queries;
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
    public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdUseCase(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCategoryQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request);
        }

        public async Task<GetCategoryQueryResult> ExecuteAsync(GetCategoryByIdQuery query)
        {
            var category = await _repository.GetByIdAsync(query.Id);
            if (category == null)
                throw new NotFoundException("Category not found");

            return _mapper.Map<GetCategoryQueryResult>(category);
        }
    }

}
