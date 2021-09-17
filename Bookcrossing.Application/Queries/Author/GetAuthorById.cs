using AutoMapper;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Queries.Author
{
    public class GetAuthorById : IRequest<AuthorDeteilsDto>
    {
        public GetAuthorById(Guid authorId)
        {
            AuthorId = authorId;
        }

        public Guid AuthorId { get; }
    }

    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorById, AuthorDeteilsDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public GetAuthorByIdHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDeteilsDto> Handle(GetAuthorById request, CancellationToken cancellationToken)
        {
            var entity = _authorRepository.GetOneByCondition(x => x.Id == request.AuthorId);

            return _mapper.Map<AuthorDeteilsDto>(entity);
        }
    }
}
