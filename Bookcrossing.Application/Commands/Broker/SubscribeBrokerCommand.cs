using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Broker;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Broker
{
    public class SubscribeBrokerCommand : IRequest
    {
        public SubscribeBrokerCommand(Subscription message)
        {
            Message = message;
        }

        public Subscription Message { get; }
    }

    public class SubscriptionBrokerCommandHandler : BaseRequestHandler<SubscribeBrokerCommand, Unit>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public SubscriptionBrokerCommandHandler(ILoggerManager logger, IPublishEndpoint publishEndpoint)
            : base(logger)
        {
            _publishEndpoint = publishEndpoint;
        }

        public override async Task<Unit> HandleInternalAsync(SubscribeBrokerCommand request, CancellationToken ct)
        {
            await _publishEndpoint.Publish(request.Message);
            return Unit.Value;
        }
    }
}
