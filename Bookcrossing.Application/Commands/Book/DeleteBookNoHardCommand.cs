using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Book
{
    public class DeleteBookNoHardCommand : IRequest
    {
        public DeleteBookNoHardCommand(Guid idBook)
        {
            IdBook = idBook;
        }

        public Guid IdBook { get; }
    }

    public class DeleteBookNoHardCommandHandler : IRequestHandler<DeleteBookNoHardCommand>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookNoHardCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteBookNoHardCommand request, CancellationToken ct)
        {
            _bookRepository.Delete(request.IdBook, ct);

            return Unit.Value;
        }
    }
}
