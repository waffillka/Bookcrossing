﻿using AutoMapper;
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
    public class GetAthorsWithParametersQuery : IRequest<ICollection<AuthorLookUpDto>>
    {
        public GetAthorsWithParametersQuery(AuthorPublisherParams authorParams)
        {
            AuthorParams = authorParams;
        }

        public AuthorPublisherParams AuthorParams { get; }
    }

    public class GetAthorsWithParametersQueryHandler : LoggerRequestHandler<GetAthorsWithParametersQuery, ICollection<AuthorLookUpDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAthorsWithParametersQueryHandler(IAuthorRepository authorRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public override async Task<ICollection<AuthorLookUpDto>> HandleInternalAsync(GetAthorsWithParametersQuery request, CancellationToken ct)
        {
            var entities = await _authorRepository.GetAsync(request.AuthorParams, ct);
            var result = _mapper.Map<ICollection<AuthorLookUpDto>>(entities);

            return result;
        }
    }
}
