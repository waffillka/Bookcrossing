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
            var result = _mediator.Send(new AddNewAuthorCommand(author));
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor([FromQuery] Guid id)
        {
            await _mediator.Send(new DeleteAuthorNoHardCommand(id));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors([FromQuery] AuthorPublisherParams parameters)
        {
            var entities = await _mediator.Send(new GetAthorsWithParametersQuery(parameters));

            return Ok(entities);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] AuthorCreationDto author)
        {
            var result = await _mediator.Send(new UpdateAuthorCommand(author));

            return Ok(result);
        }
    }
}
