using Bookcrossing.Application.Commands.Publisher;
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
        private readonly IMediator _mediatr;

        public PublisherController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetPublishers()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher([FromBody] PublisherCreationDto publisher)
        {
            var result = await _mediatr.Send(new AddNewPublisherCommand(publisher));

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _mediatr.Send(new DeletePublisherNoHardCommand(id));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PublisherCreationDto publisher)
        {
            var result = await _mediatr.Send(new UpdatePublisherCommand(publisher));

            return Ok(result);
        }
    }
}
