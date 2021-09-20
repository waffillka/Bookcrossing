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

namespace Bookcrossing.Application.Queries.Publisher
{
    public class GetPublishersWithParametersQuery : IRequest<ICollection<PublisherLookUpDto>>
    {
        public GetPublishersWithParametersQuery(AuthorPublisherParams publisherParams)
        {
            Params = publisherParams;
        }

        public AuthorPublisherParams Params { get; }
    }

    public class GetPublishersWithParametersQueryHandler : LoggerRequestHandler<GetPublishersWithParametersQuery, ICollection<PublisherLookUpDto>>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetPublishersWithParametersQueryHandler(IPublisherRepository publisherRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public override async Task<ICollection<PublisherLookUpDto>> HandleInternalAsync(GetPublishersWithParametersQuery request, CancellationToken ct)
        {
            var entities = await _publisherRepository.GetAsync(request.Params, ct);
            var result = _mapper.Map<ICollection<PublisherLookUpDto>>(entities);

            return result;
        }
    }
}
