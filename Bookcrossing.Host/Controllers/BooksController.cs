using Bookcrossing.Application.Commands.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetWithParams(GetBooksWithParametersQuery parametersQuery)
        {
            var result = _mediator.Send(parametersQuery).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
