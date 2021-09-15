using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Book
{
    public class GetBooksWithParametersQuery : IRequest<IReadOnlyCollection<Data.Entities.Book>>
    {
        public GetBooksWithParametersQuery(BookParams parameters)
        {
            Parameters = parameters;
        }

        public BookParams Parameters { get; }
    }

    public class GetBooksWithParametersQueryHandler : IRequestHandler<GetBooksWithParametersQuery, IReadOnlyCollection<Data.Entities.Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksWithParametersQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IReadOnlyCollection<Data.Entities.Book>> Handle(GetBooksWithParametersQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAsync(request.Parameters);

            return books;
        }
    }
}
