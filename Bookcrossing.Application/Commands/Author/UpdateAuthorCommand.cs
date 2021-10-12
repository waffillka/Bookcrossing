using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Author
{
    public class UpdateAuthorCommand : IRequest<AuthorDeteilsDto>
    {
        public UpdateAuthorCommand(Guid id, AuthorCreationDto author)
        {
            AuthorId = id;
            Author = author;
        }

        public AuthorCreationDto Author { get; }
        public Guid AuthorId { get; }
    }

    public class UpdateAuthorCommandHandler : BaseRequestHandler<UpdateAuthorCommand, AuthorDeteilsDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public override async Task<AuthorDeteilsDto> HandleInternalAsync(UpdateAuthorCommand request, CancellationToken ct)
        {
            var entity = await _authorRepository.GetOneByCondition(x => x.Id == request.AuthorId, ct);

            _mapper.Map(request.Author, entity);
            await _authorRepository.SaveAsync(ct);

            var result = _mapper.Map<AuthorDeteilsDto>(entity);

            return result;
        }
    }
}
