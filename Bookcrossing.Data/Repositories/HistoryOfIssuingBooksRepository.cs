using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories
{
    public class HistoryOfIssuingBooksRepository : RepositoryBase<HistoryOfIssuingBooks>, IHistoryOfIssuingBooksRepository
    {
        public HistoryOfIssuingBooksRepository(BookcrossingDbContext dbContext)
           : base(dbContext)
        {

        }

        public Task<IQueryable<HistoryOfIssuingBooks>> GetByBook(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
