using Bookcrossing.Application.Commands.Book;
using Bookcrossing.Application.Queries.Book;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace Bookcrossing.Host.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWithParams(Guid id)
        {
            var result = await _mediator.Send(new GetBookById(id));

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetWithParams([FromQuery] BookParams parameters)
        {
            var result = await _mediator.Send(new GetBooksWithParametersQuery(parameters));

            return Ok(result);
        }

        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get an alert definition by Id", OperationId = "GetAlertDefinitionById")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoHardBook([FromQuery] Guid id)
        {
            var result = await _mediator.Send(new DeleteBookCommand(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreationDto book)
        {
            var result = await _mediator.Send(new AddNewBookCommand(book));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BookCreationDto book)
        {
            var result = await _mediator.Send(new UpdateBookCommand(id, book));

            return Ok(result);
        }
    }
}
