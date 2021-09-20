using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Book
{
    public class DeleteBookNoHardCommand : IRequest
    {
        public DeleteBookNoHardCommand(Guid bookId)
        {
            BookId = bookId;
        }

        public Guid BookId { get; }
    }

    public class DeleteBookNoHardCommandHandler : LoggerRequestHandler<DeleteBookNoHardCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookNoHardCommandHandler(IBookRepository bookRepository, ILoggerManager logger)
            : base(logger)
        {
            _bookRepository = bookRepository;
        }

        public override async Task<Unit> HandleInternalAsync(DeleteBookNoHardCommand request, CancellationToken ct)
        {
            _bookRepository.Delete(request.BookId, ct);

            return Unit.Value;
        }
    }
}
