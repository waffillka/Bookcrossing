using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Book
{
    public class GetBooksWithParametersQuery : IRequest<IReadOnlyCollection<BookLookUpDto>>
    {
        public GetBooksWithParametersQuery(BookParams parameters)
        {
            Parameters = parameters;
        }

        public BookParams Parameters { get; }
    }

    public class GetBooksWithParametersQueryHandler : LoggerRequestHandler<GetBooksWithParametersQuery, IReadOnlyCollection<BookLookUpDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksWithParametersQueryHandler(IBookRepository bookRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public override async Task<IReadOnlyCollection<BookLookUpDto>> HandleInternalAsync(GetBooksWithParametersQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAsync(request.Parameters);
            var result = _mapper.Map<IReadOnlyCollection<BookLookUpDto>>(books);

            return result;
        }
    }
}
