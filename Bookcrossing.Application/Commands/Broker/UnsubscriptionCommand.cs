using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Broker;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Broker
{
    public class UnsubscriptionCommand : IRequest
    {
        public UnsubscriptionCommand(Unsubscription message)
        {
            Message = message;
        }

        public Unsubscription Message { get; }
    }

    public class UnsubscriptionCommandHandler : LoggerRequestHandler<UnsubscriptionCommand, Unit>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public UnsubscriptionCommandHandler(ILoggerManager logger, IPublishEndpoint publishEndpoint)
            : base(logger)
        {
            _publishEndpoint = publishEndpoint;
        }

        public override async Task<Unit> HandleInternalAsync(UnsubscriptionCommand request, CancellationToken ct)
        {
            await _publishEndpoint.Publish(request.Message);
            return Unit.Value;
        }
    }
}
