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
    public class UnsubscribeCommand : IRequest
    {
        public UnsubscribeCommand(Unsubscription message)
        {
            Message = message;
        }

        public UnsubscribeCommand(Guid userId, Guid bookId)
        {
            Message = new Unsubscription()
            {
                UserId = userId,
                BookId = bookId
            };
        }

        public Unsubscription Message { get; }
    }

    public class UnsubscriptionCommandHandler : BaseRequestHandler<UnsubscribeCommand, Unit>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public UnsubscriptionCommandHandler(ILoggerManager logger, IPublishEndpoint publishEndpoint)
            : base(logger)
        {
            _publishEndpoint = publishEndpoint;
        }

        public override async Task<Unit> HandleInternalAsync(UnsubscribeCommand request, CancellationToken ct)
        {
            await _publishEndpoint.Publish(request.Message);
            return Unit.Value;
        }
    }
}
