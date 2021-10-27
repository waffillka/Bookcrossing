using Bookcrossing.Application.Commands.Author;
using Bookcrossing.Application.Queries.Author;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.Context.TokenContext;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookcrossing.Host.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClientUserContext _clientUserContext;
        public AuthorsController(IMediator mediator, IClientUserContext clientUserContext)
        {
            _mediator = mediator;
            _clientUserContext = clientUserContext;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorCreationDto author)
        {
            var result = await _mediator.Send(new AddNewAuthorCommand(author));
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            await _mediator.Send(new DeleteAuthorCommand(id));
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetAuthors([FromQuery] ParametersBase parameters)
        {
            var entities = await _mediator.Send(new GetAthorsWithParametersQuery(parameters));

            return Ok(entities);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCountAuthors([FromQuery] ParametersBase parameters)
        {
            var count = await _mediator.Send(new GetCountAuthorsQuery(parameters));

            return Ok(count);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthors(Guid id)
        {
            var entities = await _mediator.Send(new GetAuthorById(id));

            return Ok(entities);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] AuthorCreationDto author)
        {
            var result = await _mediator.Send(new UpdateAuthorCommand(id, author));

            return Ok(result);
        }
    }
}
