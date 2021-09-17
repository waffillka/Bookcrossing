using AutoMapper;
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

    public class GetPublisherByIdHandler : IRequestHandler<GetPublisherById, PublisherDeteilsDto>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetPublisherByIdHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<PublisherDeteilsDto> Handle(GetPublisherById request, CancellationToken cancellationToken)
        {
            var entity = _publisherRepository.GetOneByCondition(x => x.Id == request.PublisherId);

            return _mapper.Map<PublisherDeteilsDto>(entity);
        }
    }
}
