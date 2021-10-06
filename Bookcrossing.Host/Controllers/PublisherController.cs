using Bookcrossing.Application.Commands.Publisher;
using Bookcrossing.Application.Queries.Publisher;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookcrossing.Host.Controllers
{
    [Route("api/publisher")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublisherController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublishers(Guid id)
        {
            var result = await _mediator.Send(new GetPublisherById(id));

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetWithParams([FromQuery] ParametersBase parameters)
        {
            var result = await _mediator.Send(new GetPublishersWithParametersQuery(parameters));

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePublisher([FromBody] PublisherCreationDto publisher)
        {
            var result = await _mediator.Send(new AddNewPublisherCommand(publisher));

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletePublisherCommand(id));

            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PublisherCreationDto publisher)
        {
            var result = await _mediator.Send(new UpdatePublisherCommand(id, publisher));

            return Ok(result);
        }
    }
}
