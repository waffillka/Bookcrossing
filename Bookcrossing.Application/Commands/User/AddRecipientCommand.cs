using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.User
{
    public class AddRecipientCommand : IRequest<bool>
    {
        public AddRecipientCommand(Guid bookId, Guid userId)
        {
            BookId = bookId;
            UserId = userId;
        }

        public Guid BookId { get; }
        public Guid UserId { get; }
    }

    public class AddRecipientHandler : BaseRequestHandler<AddRecipientCommand, bool>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public AddRecipientHandler(ILoggerManager logger,
            IBookRepository bookRepository,
            IUserRepository userRepository,
            IMediator mediator)
            : base(logger)
        {
            _mediator = mediator;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public override async Task<bool> HandleInternalAsync(AddRecipientCommand request, CancellationToken ct)
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

            book.RecipientId = user.Id;
            _bookRepository.SaveAsync(ct);

            return true;
        }
    }
}
