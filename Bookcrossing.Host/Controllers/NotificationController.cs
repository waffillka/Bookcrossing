using Bookcrossing.Contracts.DataTransferObjects.Broker;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bookcrossing.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;

        public NotificationController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<ActionResult> Post(string value)
        {
            await _publishEndpoint.Publish<BrokerMessage>(new
            {
                Value = value
            });

            return Ok();
        }
    }
}
