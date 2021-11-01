using Bookcrossing.Application.Commands.User;
using Bookcrossing.Application.Queries.User;
using Bookcrossing.Contracts.Context.TokenContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookcrossing.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClientUserContext _clientUserContext;

        public UserController(IMediator mediator, IClientUserContext clientUserContext)
        {
            _mediator = mediator;
            _clientUserContext = clientUserContext;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetbyId(Guid id)
        {
            var entities = await _mediator.Send(new GetUserById(id)).ConfigureAwait(false);

            return Ok(entities);
        }


        [HttpGet("authId/{authId}")]
        public async Task<IActionResult> GetbyAuthId(Guid authId)
        {
            var entities = await _mediator.Send(new GetUserByAuthId(authId));

            return Ok(entities);
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> subscribe([FromBody] Guid bookId)
        {
            var result = await _mediator.Send(new SubscribeCommand(bookId, _clientUserContext.UserId));

            return Ok(result);
        }

        [HttpPost("unsubscribe")]
        public async Task<IActionResult> unsubscribe([FromBody] Guid bookId)
        {

            var result = await _mediator.Send(new UnsubscribeCommand(bookId, _clientUserContext.UserId));

            return Ok(result);
        }

        [HttpPost("add-recipient")]
        public async Task<IActionResult> AddRecipient([FromBody] Guid bookId)
        {
            var result = await _mediator.Send(new AddRecipientCommand(bookId, _clientUserContext.UserId));

            return Ok(result);
        }

        [HttpPost("remove-recipient")]
        public async Task<IActionResult> RemoveRecipient([FromBody] Guid bookId)
        {
            var result = await _mediator.Send(new RemoveRecipientCommand(bookId, _clientUserContext.UserId));

            return Ok(result);
        }
    }
}
