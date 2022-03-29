using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Publisher
{
    public class DeletePublisherCommand : IRequest
    {
        public DeletePublisherCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class DeletePublisherCommandHandler : BaseRequestHandler<DeletePublisherCommand, Unit>
    {
        private IPublisherRepository _publisherRepository;

        public DeletePublisherCommandHandler(IPublisherRepository publisherRepository, ILoggerManager logger)
            : base(logger)
        {
            _publisherRepository = publisherRepository;
        }

        public override async Task<Unit> HandleInternalAsync(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            _publisherRepository.Delete(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
