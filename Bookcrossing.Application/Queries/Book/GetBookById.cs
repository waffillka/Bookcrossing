using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Queries.Book
{
    public class GetBookById : IRequest<BookDeteilsDto>
    {
        public GetBookById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class GetBookByIdHandler : LoggerRequestHandler<GetBookById, BookDeteilsDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdHandler(IBookRepository bookRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public override async Task<BookDeteilsDto> HandleInternalAsync(GetBookById request, CancellationToken cancellationToken)
        {
            var entity = _bookRepository.GetOneByCondition(x => x.Id == request.Id);

            return _mapper.Map<BookDeteilsDto>(entity);
        }
    }
}
