using Bookcrossing.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IHistoryOfIssuingBooksRepository : IRepositoryBase<HistoryOfIssuingBooks>
    {
        Task<HistoryOfIssuingBooks> GetByBook(Guid id);

    }
}
