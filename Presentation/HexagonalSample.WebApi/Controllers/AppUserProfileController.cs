using HexagonalSample.Application.DtoClasses.AppUserProfiles.Commands;
using HexagonalSample.Application.DtoClasses.AppUserProfiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserProfileList()
        {
            List<GetAppUserProfileQueryResult> appUsers = await _mediator.Send(new GetAppUserProfilesQuery());
            return Ok(appUsers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserProfile(int id)
        {
            GetAppUserProfileQueryResult value = await _mediator.Send(new GetAppUserProfileByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUserProfile(CreateAppUserProfileCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUserProfile(UpdateAppUserProfileCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppUserProfile(int id)
        {
            return Ok(await _mediator.Send(new RemoveAppUserProfileCommand(id)));
        }
    }
}
