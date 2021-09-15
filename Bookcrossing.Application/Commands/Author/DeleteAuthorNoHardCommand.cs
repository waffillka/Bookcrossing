using AutoMapper;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Author
{
    public class DeleteAuthorNoHardCommand : IRequest
    {
        public DeleteAuthorNoHardCommand(Guid idAuthor)
        {
            IdAuthor = idAuthor;
        }

        public Guid IdAuthor { get; }
    }

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorNoHardCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteAuthorNoHardCommand request, CancellationToken ct)
        {
            var entityToRemove = await _authorRepository.GetOneByCondition(x => x.Id == request.IdAuthor, ct);
            _authorRepository.Delete(entityToRemove, ct);

            return Unit.Value;
        }      
    }
}
