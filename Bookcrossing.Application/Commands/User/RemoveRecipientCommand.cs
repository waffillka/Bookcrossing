using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.User
{
    public class RemoveRecipientCommand : IRequest<bool>
    {
        public RemoveRecipientCommand(Guid bookId, Guid userId)
        {
            BookId = bookId;
            UserId = userId;
        }

        public Guid BookId { get; }
        public Guid UserId { get; }
    }

    public class RemoveRecipientHandler : BaseRequestHandler<RemoveRecipientCommand, bool>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public RemoveRecipientHandler(ILoggerManager logger,
            IBookRepository bookRepository,
            IUserRepository userRepository,
            IMediator mediator)
            : base(logger)
        {
            _mediator = mediator;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public override async Task<bool> HandleInternalAsync(RemoveRecipientCommand request, CancellationToken ct)
        {
            var book = await _bookRepository.GetAsync(request.BookId, ct);
            var user = await _userRepository.GetByAuthIdAsync(request.UserId, ct);

            if (book == default || user == default)
            {
                return false;
            }

            if (book.RecipientId != user.Id)
            {
                return false;
            }

            book.RecipientId = null;
            _bookRepository.SaveAsync(ct);

            return true;
        }
    }
}
