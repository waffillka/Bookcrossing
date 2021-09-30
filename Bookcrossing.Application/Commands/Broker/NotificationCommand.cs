using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Broker;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Broker
{
    public class NotificationCommand : IRequest
    {
        public NotificationCommand(Notification message)
        {
            Message = message;
        }

        public Notification Message { get; }
    }

    public class NotificationCommandHandler : LoggerRequestHandler<NotificationCommand, Unit>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public NotificationCommandHandler(ILoggerManager logger, IPublishEndpoint publishEndpoint)
            : base(logger)
        {
            _publishEndpoint = publishEndpoint;
        }

        public override async Task<Unit> HandleInternalAsync(NotificationCommand request, CancellationToken ct)
        {
            await _publishEndpoint.Publish(request.Message);
            return Unit.Value;
        }
    }
}
