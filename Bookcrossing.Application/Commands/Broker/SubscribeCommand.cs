using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Broker;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Broker
{
    public class SubscribeCommand : IRequest
    {
        public SubscribeCommand(Subscription message)
        {
            Message = message;
        }

        public Subscription Message { get; }
    }

    public class SubscriptionCommandHandler : BaseRequestHandler<NotifyCommand, Unit>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public SubscriptionCommandHandler(ILoggerManager logger, IPublishEndpoint publishEndpoint)
            : base(logger)
        {
            _publishEndpoint = publishEndpoint;
        }

        public override async Task<Unit> HandleInternalAsync(NotifyCommand request, CancellationToken ct)
        {
            await _publishEndpoint.Publish(request.Message);
            return Unit.Value;
        }
    }
}
