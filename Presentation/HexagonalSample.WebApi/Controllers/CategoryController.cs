using HexagonalSample.Application.DtoClasses.Categories.Commands;
using HexagonalSample.Application.DtoClasses.Categories.Queries;
using HexagonalSample.Application.PrimaryPorts.CategoryPorts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.WebApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AppCategoryList()
        {
            List<GetCategoryQueryResult> categorys = await _mediator.Send(new GetCategoryQuery());
            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            GetCategoryQueryResult value = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok(await _mediator.Send(new RemoveCategoryCommand(id)));
        }
    }
}
