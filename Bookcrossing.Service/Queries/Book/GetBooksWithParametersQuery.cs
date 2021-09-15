using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Book
{
    public class GetBooksWithParametersQuery : IRequest<IQueryable<Data.Entities.Book>>
    {
        public GetBooksWithParametersQuery()
        {

        }

        public BookParams Parameters { get; }
    }

    public class GetBooksWithParametersQueryHandler : IRequestHandler<GetBooksWithParametersQuery, IQueryable<Data.Entities.Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksWithParametersQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IQueryable<Data.Entities.Book>> Handle(GetBooksWithParametersQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAsync(request.Parameters);

            return books;
        }
    }
}
