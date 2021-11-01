using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.User
{
    public class AddRecipient : IRequest<bool>
    {
        public AddRecipient(Guid bookId, Guid userId)
        {
            BookId = bookId;
            UserId = userId;
        }

        public Guid BookId { get; }
        public Guid UserId { get; }
    }

    public class AddRecipientHandler : BaseRequestHandler<AddRecipient, bool>
    {
        public AddRecipientHandler(ILoggerManager logger)
            : base(logger)
        {
        }

        public override async Task<bool> HandleInternalAsync(AddRecipient request, CancellationToken ct)
        {
            return false;
        }
    }
}
