using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories
{
    public class HistoryOfIssuingBooksRepository : RepositoryBase<HistoryOfIssuingBooks>, IHistoryOfIssuingBooksRepository
    {
        public HistoryOfIssuingBooksRepository(BookcrossingDbContext dbContext)
           : base(dbContext)
        {

        }

        public Task<IQueryable<HistoryOfIssuingBooks>> GetAsync(HistoryParams parametrs, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
