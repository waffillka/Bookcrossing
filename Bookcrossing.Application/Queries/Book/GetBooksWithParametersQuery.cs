using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Book
{
    public class GetBooksWithParametersQuery : IRequest<IReadOnlyCollection<BookDeteilsDto>>
    {
        public GetBooksWithParametersQuery(BookParams parameters)
        {
            Parameters = parameters;
        }

        public BookParams Parameters { get; }
    }

    public class GetBooksWithParametersQueryHandler : LoggerRequestHandler<GetBooksWithParametersQuery, IReadOnlyCollection<BookDeteilsDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksWithParametersQueryHandler(IBookRepository bookRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public override async Task<IReadOnlyCollection<BookDeteilsDto>> HandleInternalAsync(GetBooksWithParametersQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAsync(request.Parameters);
            var result = _mapper.Map<IReadOnlyCollection<BookDeteilsDto>>(books);

            return result;
        }
    }
}
