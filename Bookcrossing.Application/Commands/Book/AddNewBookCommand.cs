using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Book
{
    public class AddNewBookCommand : IRequest<BookDeteilsDto>
    {
        public AddNewBookCommand(BookCreationDto book)
        {
            Book = book;
        }

        public BookCreationDto Book { get; }
    }

    public class AddNewBookCommandHandler : BaseRequestHandler<AddNewBookCommand, BookDeteilsDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddNewBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public override async Task<BookDeteilsDto> HandleInternalAsync(AddNewBookCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Data.Entities.Book>(request.Book);
            entity = await _bookRepository.InsertAsync(entity, ct);
            var result = _mapper.Map<BookDeteilsDto>(entity);

            return result;
        }
    }
}
