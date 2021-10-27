using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Queries.Author
{
    public class GetCountAuthorsQuery : IRequest<long>
    {
        public GetCountAuthorsQuery(ParametersBase authorParams)
        {
            AuthorParams = authorParams;
        }

        public ParametersBase AuthorParams { get; }
    }

    public class GetCountAuthorsQueryHandler : BaseRequestHandler<GetCountAuthorsQuery, long>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetCountAuthorsQueryHandler(IAuthorRepository authorRepository, ILoggerManager logger)
            : base(logger)
        {
            _authorRepository = authorRepository;
        }

        public override Task<long> HandleInternalAsync(GetCountAuthorsQuery request, CancellationToken ct)
        {
            var count = _authorRepository.GetCount(request.AuthorParams, ct);

            return count;
        }
    }
}
