using Bookcrossing.Application.Commands.Author;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateAuthor(AddNewAuthorCommand cmd)
        {
            var result = _mediator.Send(cmd).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAuthor(DeleteAuthorNoHardCommand cmd)
        {
            await _mediator.Send(cmd).ConfigureAwait(false);
            return Ok();
        }
    }
}
