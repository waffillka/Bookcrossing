using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IHistoryOfIssuingBooksRepository : IRepositoryBase<HistoryOfIssuingBooks>
    {
        Task<IQueryable<HistoryOfIssuingBooks>> GetAsync(HistoryParams parametrs, CancellationToken ct = default);
    }
}
