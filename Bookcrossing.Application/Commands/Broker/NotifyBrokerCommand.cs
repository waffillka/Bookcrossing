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
    public class NotifyBrokerCommand : IRequest
    {
        public NotifyBrokerCommand(Notification message)
        {
            Message = message;
        }

        public NotifyBrokerCommand(Guid bookId)
        {
            Message = new Notification()
            {
                BookId = bookId
            };
        }

        public Notification Message { get; }
    }

    public class NotificationBrokerCommandHandler : BaseRequestHandler<NotifyBrokerCommand, Unit>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public NotificationBrokerCommandHandler(ILoggerManager logger, IPublishEndpoint publishEndpoint)
            : base(logger)
        {
            _publishEndpoint = publishEndpoint;
        }

        public override async Task<Unit> HandleInternalAsync(NotifyBrokerCommand request, CancellationToken ct)
        {
            await _publishEndpoint.Publish(request.Message);
            return Unit.Value;
        }
    }
}
