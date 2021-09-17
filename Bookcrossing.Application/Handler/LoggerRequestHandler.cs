using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Handler
{
    public abstract class LoggerRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            // log

            return HandleInternalAsync(request, cancellationToken);
        }

        public abstract Task<TResponse> HandleInternalAsync(TRequest request, CancellationToken cancellationToken);
    }
}
