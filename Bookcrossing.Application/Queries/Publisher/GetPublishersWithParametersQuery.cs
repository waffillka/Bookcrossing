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
    public class GetPublishersWithParametersQuery : IRequest<IReadOnlyCollection<PublisherLookUpDto>>
    {
        public GetPublishersWithParametersQuery(ParametersBase publisherParams)
        {
            Params = publisherParams;
        }

        public ParametersBase Params { get; }
    }

    public class GetPublishersWithParametersQueryHandler : BaseRequestHandler<GetPublishersWithParametersQuery, IReadOnlyCollection<PublisherLookUpDto>>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetPublishersWithParametersQueryHandler(IPublisherRepository publisherRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public override async Task<IReadOnlyCollection<PublisherLookUpDto>> HandleInternalAsync(GetPublishersWithParametersQuery request, CancellationToken ct)
        {
            var entities = await _publisherRepository.GetAsync(request.Params, ct);
            var result = _mapper.Map<IReadOnlyCollection<PublisherLookUpDto>>(entities);

            return result;
        }
    }
}
