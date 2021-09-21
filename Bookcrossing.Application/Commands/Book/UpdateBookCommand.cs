﻿using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Book
{
    public class UpdateBookCommand : IRequest<BookDeteilsDto>
    {
        public UpdateBookCommand(Guid id, BookCreationDto book)
        {
            BookId = id;
            Book = book;
        }

        public Guid BookId { get; }
        public BookCreationDto Book { get; }
    }

    public class UpdateBookCommandHandler : LoggerRequestHandler<UpdateBookCommand, BookDeteilsDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public override async Task<BookDeteilsDto> HandleInternalAsync(UpdateBookCommand request, CancellationToken ct)
        {
            var entity = await _bookRepository.GetOneByCondition(x => x.Id == request.BookId, ct);

            _mapper.Map(request.Book, entity);

            await _bookRepository.SaveAsync(ct);
            var result = _mapper.Map<BookDeteilsDto>(entity);

            return result;
        }
    }
}