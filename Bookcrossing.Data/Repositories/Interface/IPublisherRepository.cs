using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IPublisherRepository : IRepositoryBase<Publisher>
    {
        Task<IReadOnlyCollection<Publisher>> GetAsync(RequestFeatures parametrs, CancellationToken ct = default);
    }
}
