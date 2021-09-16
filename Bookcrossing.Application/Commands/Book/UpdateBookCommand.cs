using AutoMapper;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Book
{
    public class UpdateBookCommand : IRequest<BookDeteilsDto>
    {
        public UpdateBookCommand(BookCreationDto book)
        {
            Book = book;
        }

        public BookCreationDto Book { get; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDeteilsDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDeteilsDto> Handle(UpdateBookCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Data.Entities.Book>(request.Book);
            entity = await _bookRepository.UpdateAsync(entity, ct);
            var result = _mapper.Map<BookDeteilsDto>(entity);

            return result;
        }
    }
}
