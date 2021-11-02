using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.User
{
    public class CreateUser : IRequest
    {
        public CreateUser()
        {
        }
    }

    public class CreateUserHandler : BaseRequestHandler<CreateUser, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public CreateUserHandler(ILoggerManager logger,
            IUserRepository userRepository,
            IMediator mediator)
            : base(logger)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public override async Task<Unit> HandleInternalAsync(CreateUser request, CancellationToken ct)
        {
            return Unit.Value;
        }
    }
}
