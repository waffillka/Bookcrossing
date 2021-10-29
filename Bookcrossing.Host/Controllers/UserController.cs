using Bookcrossing.Application.Queries.User;
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
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
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

        //recipient unlock
        //recipient lock
        //subcrabe 
        //unsubcrabe
    }
}
