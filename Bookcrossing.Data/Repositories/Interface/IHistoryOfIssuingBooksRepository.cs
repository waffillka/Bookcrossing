using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IHistoryOfIssuingBooksRepository : IRepositoryBase<HistoryOfIssuingBooks>
    {
        Task<IReadOnlyCollection<HistoryOfIssuingBooks>> GetAsync(HistoryParams parametrs, CancellationToken ct = default);
    }
}
