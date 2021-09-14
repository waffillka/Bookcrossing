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

        public async Task<IQueryable<HistoryOfIssuingBooks>> GetAsync(HistoryParams parameters, CancellationToken ct = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            IQueryable<HistoryOfIssuingBooks> entities = _dbContext.HistoryOfIssuingBooks;

            if (parameters.From != default)
            {
                if (parameters.To != default)
                {
                    entities = entities.Where(item => item.DateOfReceiving.Date >= parameters.From.Date && item.DateOfDelivery <= parameters.To);
                }
                else
                {
                    entities = entities.Where(snippet => snippet.DateOfReceiving.Date >= parameters.From.Date);
                }
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchString))
            {
                entities = entities.Where(x => x.Book.ISBIN.Contains(parameters.SearchString) || x.Book.Name.Contains(parameters.SearchString));
            }

            return entities;
        }
    }
}
