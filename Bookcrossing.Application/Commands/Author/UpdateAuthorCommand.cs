using AutoMapper;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Author
{
    public class UpdateAuthorCommand : IRequest<AuthorDeteilsDto>
    {
        public UpdateAuthorCommand(AuthorCreationDto author)
        {
            Author = author;
        }

        public AuthorCreationDto Author { get; }
    }

    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorDeteilsDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDeteilsDto> Handle(UpdateAuthorCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Data.Entities.Author>(request.Author);
            entity = await _authorRepository.UpdateAsync(entity, ct);
            var result = _mapper.Map<AuthorDeteilsDto>(entity);

            return result;
        }
    }
}
