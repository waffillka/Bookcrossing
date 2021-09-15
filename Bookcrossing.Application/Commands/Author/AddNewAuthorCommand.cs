using AutoMapper;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Author
{
    public class AddNewAuthorCommand : IRequest<AuthorDeteilsDto>
    {
        public AddNewAuthorCommand(AuthorCreationDto athor)
        {
            Athor = athor;
        }

        public AuthorCreationDto Athor { get; }
    }

    public class AddNewAuthorCommandHandler : IRequestHandler<AddNewAuthorCommand, AuthorDeteilsDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public AddNewAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<AuthorDeteilsDto> Handle(AddNewAuthorCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Data.Entities.Author>(request.Athor);
            entity = await _authorRepository.InsertAsync(entity, ct);
            var result = _mapper.Map<AuthorDeteilsDto>(entity);

            return result;
        }
    }
}
