using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Queries.Author
{
    public class GetAthorsWithParametersQuery : IRequest<IReadOnlyCollection<AuthorLookUpDto>>
    {
        public GetAthorsWithParametersQuery(ParametersBase authorParams)
        {
            AuthorParams = authorParams;
        }

        public ParametersBase AuthorParams { get; }
    }

    public class GetAthorsWithParametersQueryHandler : BaseRequestHandler<GetAthorsWithParametersQuery, IReadOnlyCollection<AuthorLookUpDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAthorsWithParametersQueryHandler(IAuthorRepository authorRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public override async Task<IReadOnlyCollection<AuthorLookUpDto>> HandleInternalAsync(GetAthorsWithParametersQuery request, CancellationToken ct)
        {
            var entities = await _authorRepository.GetAsync(request.AuthorParams, ct);
            var result = _mapper.Map<IReadOnlyCollection<AuthorLookUpDto>>(entities);

            return result;
        }
    }
}
