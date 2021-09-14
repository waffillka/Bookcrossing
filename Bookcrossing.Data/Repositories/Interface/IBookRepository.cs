using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<IQueryable<Book>> GetAsync(BookParams parameters, CancellationToken ct = default);
    }
}
