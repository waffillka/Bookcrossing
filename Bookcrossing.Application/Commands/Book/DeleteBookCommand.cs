using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Book
{
    public class DeleteBookCommand : IRequest
    {
        public DeleteBookCommand(Guid bookId)
        {
            BookId = bookId;
        }

        public Guid BookId { get; }
    }

    public class DeleteBookCommandHandler : BaseRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository, ILoggerManager logger)
            : base(logger)
        {
            _bookRepository = bookRepository;
        }

        public override async Task<Unit> HandleInternalAsync(DeleteBookCommand request, CancellationToken ct)
        {
            _bookRepository.Delete(request.BookId, ct);

            return Unit.Value;
        }
    }
}
