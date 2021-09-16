using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Author
{
    public class DeleteAuthorNoHardCommand : IRequest
    {
        public DeleteAuthorNoHardCommand(Guid idAuthor)
        {
            IdAuthor = idAuthor;
        }

        public Guid IdAuthor { get; }
    }

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorNoHardCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<Unit> Handle(DeleteAuthorNoHardCommand request, CancellationToken ct)
        {
            _authorRepository.Delete(request.IdAuthor, ct);

            return Unit.Value;
        }      
    }
}
