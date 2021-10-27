using Bookcrossing.Application.Queries.User;
using Bookcrossing.Contracts.Context.TokenContext;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public async Task<IActionResult> GetbyId([FromQuery] Guid id)
        {
            UserDeteilsDto entities = await _mediator.Send(new GetUserById(id));

            return Ok(entities);
        }
    }
}
