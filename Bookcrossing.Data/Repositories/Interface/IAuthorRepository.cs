using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        Task<IQueryable<Author>> GetAsync(AuthorPublisherParams parametrs, CancellationToken ct = default);
    }
}
