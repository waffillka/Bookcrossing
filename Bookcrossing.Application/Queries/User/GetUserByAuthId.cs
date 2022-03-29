using AutoMapper;
using Bookcrossing.Application.Handler;
using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Data.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Application.Queries.User
{
    public class GetUserByAuthId : IRequest<UserDeteilsDto>
    {
        public GetUserByAuthId(Guid id)
        {
            AuthId = id;
        }

        public Guid AuthId { get; }
    }

    public class GetUserByAuthIdHandler : BaseRequestHandler<GetUserByAuthId, UserDeteilsDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByAuthIdHandler(IUserRepository userRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public override async Task<UserDeteilsDto> HandleInternalAsync(GetUserByAuthId request, CancellationToken ct)
        {
            var entity = await _userRepository.GetByAuthIdAsync(request.AuthId, ct);

            return _mapper.Map<UserDeteilsDto>(entity);
        }
    }
}
