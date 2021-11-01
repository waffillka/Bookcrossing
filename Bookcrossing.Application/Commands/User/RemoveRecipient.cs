using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.User
{
    public class RemoveRecipient : IRequest<bool>
    {
        public RemoveRecipient(Guid bookId, Guid userId)
        {
            BookId = bookId;
            UserId = userId;
        }

        public Guid BookId { get; }
        public Guid UserId { get; }
    }

    public class RemoveRecipientHandler : BaseRequestHandler<RemoveRecipient, bool>
    {
        public RemoveRecipientHandler(ILoggerManager logger)
            : base(logger)
        {
        }

        public override async Task<bool> HandleInternalAsync(RemoveRecipient request, CancellationToken ct)
        {
            return false;
        }
    }
}
