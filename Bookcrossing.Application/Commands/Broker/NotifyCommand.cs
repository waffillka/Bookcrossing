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
    public class NotifyCommand : IRequest
    {
        public NotifyCommand(Notification message)
        {
            Message = message;
        }

        public NotifyCommand(Guid bookId)
        {
            Message = new Notification()
            {
                BookId = bookId
            };
        }

        public Notification Message { get; }
    }

    public class NotificationCommandHandler : BaseRequestHandler<NotifyCommand, Unit>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public NotificationCommandHandler(ILoggerManager logger, IPublishEndpoint publishEndpoint)
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
