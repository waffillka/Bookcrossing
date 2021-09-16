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

    public class DeletePublisherNoHardCommandHandler : IRequestHandler<DeletePublisherNoHardCommand>
    {
        private IPublisherRepository _publisherRepository;
        public DeletePublisherNoHardCommandHandler(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<Unit> Handle(DeletePublisherNoHardCommand request, CancellationToken cancellationToken)
        {
            _publisherRepository.Delete(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
