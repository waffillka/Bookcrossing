using Bookcrossing.Application.Commands.Author;
using Bookcrossing.Application.Queries.Author;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookcrossing.Host.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorCreationDto author)
        {
            var result = await _mediator.Send(new AddNewAuthorCommand(author));
            return Ok(result);
        }

        [HttpDelete("{id}")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthors(Guid id)
        {
            var entities = await _mediator.Send(new GetAuthorById(id));

            return Ok(entities);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] AuthorCreationDto author)
        {
            var result = await _mediator.Send(new UpdateAuthorCommand(id, author));

            return Ok(result);
        }
    }
}
