using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Broker;
using MassTransit;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Broker
{
    public class UnsubscribeBrokerCommand : IRequest
    {
        public UnsubscribeBrokerCommand(Unsubscription message)
        {
            Message = message;
        }

        public UnsubscribeBrokerCommand(Guid userId, Guid bookId)
        {
            Message = new Unsubscription()
            {
                UserId = userId,
                BookId = bookId
            };
        }

        public Unsubscription Message { get; }
    }

    public class UnsubscriptionBrokerCommandHandler : BaseRequestHandler<UnsubscribeBrokerCommand, Unit>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public UnsubscriptionBrokerCommandHandler(ILoggerManager logger, IPublishEndpoint publishEndpoint)
            : base(logger)
        {
            _publishEndpoint = publishEndpoint;
        }

        public override async Task<Unit> HandleInternalAsync(UnsubscribeBrokerCommand request, CancellationToken ct)
        {
            await _publishEndpoint.Publish(request.Message);
            return Unit.Value;
        }
    }
}
