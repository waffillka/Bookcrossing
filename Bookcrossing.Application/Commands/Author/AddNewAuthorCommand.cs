using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
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
            Author = athor;
        }

        public AuthorCreationDto Author { get; }
    }

    public class AddNewAuthorCommandHandler : LoggerRequestHandler<AddNewAuthorCommand, AuthorDeteilsDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public AddNewAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository, ILoggerManager logger)
            : base(logger)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public override async Task<AuthorDeteilsDto> HandleInternalAsync(AddNewAuthorCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Data.Entities.Author>(request.Author);
            entity = await _authorRepository.InsertAsync(entity, ct);
            var result = _mapper.Map<AuthorDeteilsDto>(entity);

            return result;
        }
    }
}
