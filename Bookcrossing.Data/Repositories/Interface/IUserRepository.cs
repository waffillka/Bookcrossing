using Bookcrossing.Data.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByAuthIdAsync(Guid id, CancellationToken ct = default);
        Task<User> GetByIdAsync(Guid id, CancellationToken ct = default);
    }
}
