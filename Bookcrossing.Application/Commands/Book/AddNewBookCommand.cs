﻿using AutoMapper;
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

    public class AddNewBookCommandHandler : IRequestHandler<AddNewBookCommand, BookDeteilsDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddNewBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDeteilsDto> Handle(AddNewBookCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Data.Entities.Book>(request.Book);
            entity = await _bookRepository.InsertAsync(entity, ct);
            var result = _mapper.Map<BookDeteilsDto>(entity);

            return result;
        }
    }
}
