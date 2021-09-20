using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Author
{
    public class DeleteAuthorNoHardCommand : IRequest
    {
        public DeleteAuthorNoHardCommand(Guid authorId)
        {
            AuthorId = authorId;
        }

        public Guid AuthorId { get; }
    }

    public class DeleteAuthorCommandHandler : LoggerRequestHandler<DeleteAuthorNoHardCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, ILoggerManager logger)
            : base(logger)
        {
            _authorRepository = authorRepository;
        }

        public override async Task<Unit> HandleInternalAsync(DeleteAuthorNoHardCommand request, CancellationToken ct)
        {
            _authorRepository.Delete(request.AuthorId, ct);

            return Unit.Value;
        }      
    }
}
