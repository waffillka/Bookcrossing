using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<IReadOnlyCollection<Book>> GetAsync(BookParams parameters, CancellationToken ct = default);
    }
}
