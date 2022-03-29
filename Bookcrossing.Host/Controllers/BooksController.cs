using Bookcrossing.Application.Commands.Book;
using Bookcrossing.Application.Queries.Book;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookcrossing.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
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

        [HttpGet("count")]
        public async Task<IActionResult> GetCountBooks([FromQuery] BookParams parameters)
        {
            var count = await _mediator.Send(new GetCountBooksQuery(parameters));

            return Ok(count);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNoHardBook([FromQuery] Guid id)
        {
            var result = await _mediator.Send(new DeleteBookCommand(id));

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBook([FromBody] BookCreationDto book)
        {
            var result = await _mediator.Send(new AddNewBookCommand(book));
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BookCreationDto book)
        {
            var result = await _mediator.Send(new UpdateBookCommand(id, book));

            return Ok(result);
        }
    }
}
