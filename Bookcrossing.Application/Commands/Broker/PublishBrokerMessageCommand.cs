using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Broker;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Broker
{
    public class PublishBrokerMessageCommand : IRequest
    {
        public PublishBrokerMessageCommand(BrokerMessage message)
        {
            Message = message;
        }

        public BrokerMessage Message { get; }
    }

    public class PublishBrokerMessageCommandHandler : LoggerRequestHandler<PublishBrokerMessageCommand, Unit>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishBrokerMessageCommandHandler(ILoggerManager logger, IPublishEndpoint publishEndpoint)
            : base(logger)
        {
            _publishEndpoint = publishEndpoint;
        }

        public override async Task<Unit> HandleInternalAsync(PublishBrokerMessageCommand request, CancellationToken ct)
        {
            await _publishEndpoint.Publish(request.Message);
            return Unit.Value;
        }
    }
}
