using Bookcrossing.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IHistoryOfIssuingBooksRepository : IRepositoryBase<HistoryOfIssuingBooks>
    {
        Task<IQueryable<HistoryOfIssuingBooks>> GetByBook(Guid id);

    }
}
