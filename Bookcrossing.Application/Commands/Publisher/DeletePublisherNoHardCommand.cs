using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Publisher
{
    public class DeletePublisherNoHardCommand : IRequest
    {
        public DeletePublisherNoHardCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class DeletePublisherNoHardCommandHandler : LoggerRequestHandler<DeletePublisherNoHardCommand, Unit>
    {
        private IPublisherRepository _publisherRepository;

        public DeletePublisherNoHardCommandHandler(IPublisherRepository publisherRepository, ILoggerManager logger)
            : base(logger)
        {
            _publisherRepository = publisherRepository;
        }

        public override async Task<Unit> HandleInternalAsync(DeletePublisherNoHardCommand request, CancellationToken cancellationToken)
        {
            _publisherRepository.Delete(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
