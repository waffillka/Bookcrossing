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
    public class GetUserById : IRequest<UserDeteilsDto>
    {
        public GetUserById(Guid id)
        {
            UserId = id;
        }

        public Guid UserId { get; set; }
    }

    public class GetUserByIdHandler : BaseRequestHandler<GetUserById, UserDeteilsDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper, ILoggerManager logger)
            : base(logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public override async Task<UserDeteilsDto> HandleInternalAsync(GetUserById request, CancellationToken ct)
        {
            var entity = await _userRepository.GetByIdAsync(request.UserId, ct);

            return _mapper.Map<UserDeteilsDto>(entity);
        }
    }
}
