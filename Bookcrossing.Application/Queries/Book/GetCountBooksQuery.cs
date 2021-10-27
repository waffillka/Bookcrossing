using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Queries.Book
{
    public class GetCountBooksQuery : IRequest<long>
    {
        public GetCountBooksQuery(BookParams parameters)
        {
            Parameters = parameters;
        }

        public BookParams Parameters { get; }
    }

    public class GetCountBooksQueryHandler : BaseRequestHandler<GetCountBooksQuery, long>
    {
        private readonly IBookRepository _bookRepository;

        public GetCountBooksQueryHandler(IBookRepository bookRepository, ILoggerManager logger)
            : base(logger)
        {
            _bookRepository = bookRepository;
        }

        public override async Task<long> HandleInternalAsync(GetCountBooksQuery request, CancellationToken cancellationToken)
        {
            var count = _bookRepository.GetCountAsync(request.Parameters, cancellationToken);
            

            return count.Result;
        }
    }
}
