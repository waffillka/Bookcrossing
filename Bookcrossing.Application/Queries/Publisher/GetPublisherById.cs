using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Queries.Publisher
{
    public class GetPublisherById : IRequest<PublisherDeteilsDto>
    {
        public GetPublisherById(Guid id)
        {
            PublisherId = id;
        }

        public Guid PublisherId {get;}
    }

    public class GetPublisherByIdHandler : LoggerRequestHandler<GetPublisherById, PublisherDeteilsDto>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetPublisherByIdHandler(IPublisherRepository publisherRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public override async Task<PublisherDeteilsDto> HandleInternalAsync(GetPublisherById request, CancellationToken cancellationToken)
        {
            var entity = _publisherRepository.GetOneByCondition(x => x.Id == request.PublisherId);

            return _mapper.Map<PublisherDeteilsDto>(entity);
        }
    }
}
