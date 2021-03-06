using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.Enumeration;
using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BookcrossingDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IQueryable<Publisher>> GetAsync(AuthorPublisherParams parameters, CancellationToken ct = default)
        {
            var entities = DbContext.Publishers.Where(x => x.Name.Contains(parameters.SearchString));

            entities = parameters.OrderBy == Order.Asc ? entities.OrderBy(x => x.Name) : entities.OrderByDescending(x => x.Name);

            return entities.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize); ;
        }
    }
}
