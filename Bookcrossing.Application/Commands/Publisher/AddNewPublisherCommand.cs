using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Publisher
{
    public class AddNewPublisherCommand : IRequest<PublisherDeteilsDto>
    {
        public AddNewPublisherCommand(PublisherCreationDto publisher)
        {
            Publisher = publisher;
        }

        public PublisherCreationDto Publisher { get; }
    }

    public class AddNewPublisherCommandHandler : BaseRequestHandler<AddNewPublisherCommand, PublisherDeteilsDto>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public AddNewPublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public override async Task<PublisherDeteilsDto> HandleInternalAsync(AddNewPublisherCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Data.Entities.Publisher>(request.Publisher);
            entity = await _publisherRepository.InsertAsync(entity, cancellationToken);
            var result = _mapper.Map<PublisherDeteilsDto>(entity);

            return result;
        }
    }
}
