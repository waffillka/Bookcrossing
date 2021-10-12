using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Publisher
{
    public class UpdatePublisherCommand : IRequest<PublisherLookUpDto>
    {
        public UpdatePublisherCommand(Guid id, PublisherCreationDto publisher)
        {
            PublisherId = id;
            Publisher = publisher;
        }

        public Guid PublisherId { get; }
        public PublisherCreationDto Publisher { get; }
    }

    public class UpdatePublisherCommandHandler : BaseRequestHandler<UpdatePublisherCommand, PublisherLookUpDto>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public UpdatePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _mapper = mapper;
            _publisherRepository = publisherRepository;
        }

        public override async Task<PublisherLookUpDto> HandleInternalAsync(UpdatePublisherCommand request, CancellationToken ct)
        {
            var entity = await _publisherRepository.GetOneByCondition(x => x.Id == request.PublisherId, ct);

            _mapper.Map(request.Publisher, entity);
            await _publisherRepository.SaveAsync(ct);
            var result = _mapper.Map<PublisherLookUpDto>(entity);

            return result;
        }
    }
}
