using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Broker;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.User
{
    public class SubscribeCommand : IRequest<bool>
    {
        public SubscribeCommand(Guid bookId, Guid userId)
        {
            BookId = bookId;
            UserId = userId;
        }

        public Guid BookId { get; }
        public Guid UserId { get; }
    }

    public class SubscribeCommandHandler : BaseRequestHandler<SubscribeCommand, bool>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public SubscribeCommandHandler(ILoggerManager logger,
            IBookRepository bookRepository,
            IUserRepository userRepository,
            IMediator mediator)
            : base(logger)
        {
            _mediator = mediator;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public override async Task<bool> HandleInternalAsync(SubscribeCommand request, CancellationToken ct)
        {
            var book = await _bookRepository.GetAsync(request.BookId, ct);
            var user = await _userRepository.GetByAuthIdAsync(request.UserId, ct);

            if (book == default || user == default || user.Subscribe.Contains(book))
            {
                return false;
            }

            user.Subscribe.Add(book);
            await _userRepository.SaveAsync(ct);

            var subscription = new Subscription()
            {
                UserId = user.Id,

                UserName = user.Nickname,
                UserNickname = user.Nickname,
                UserEmail = user.Email,
                SubscriptionDate = DateTime.Now,
                BookId = book.Id,
                BookName = book.Name,
                BookISBIN = book.ISBIN,
                Authors = book.Authors.Select(x => x.Name).ToList()
            };

            await _mediator.Send(new Broker.SubscribeBrokerCommand(subscription));
            await _mediator.Send(new Broker.NotifyBrokerCommand(book.Id));
            return true;
        }
    }
}
