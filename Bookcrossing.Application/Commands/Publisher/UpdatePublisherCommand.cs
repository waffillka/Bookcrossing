using AutoMapper;
using Bookcrossing.Contracts.DataTransferObjects.Creation;
using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Commands.Publisher
{
    public class UpdatePublisherCommand: IRequest<PublisherLookUpDto>
    {
        public UpdatePublisherCommand(PublisherCreationDto publisher)
        {
            Publisher = publisher;
        }

        public PublisherCreationDto Publisher { get; }
    }

    public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, PublisherLookUpDto>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public UpdatePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _mapper = mapper;
            _publisherRepository = publisherRepository;
        }

        public async Task<PublisherLookUpDto> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Data.Entities.Publisher>(request.Publisher);
            entity = await _publisherRepository.UpdateAsync(entity);
            var result = _mapper.Map<PublisherLookUpDto>(entity);

            return result;
        }
    }
}
