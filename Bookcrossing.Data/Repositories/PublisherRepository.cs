using Bookcrossing.Contracts.Abstractions.RequestFeatures;
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

        public async Task<IQueryable<Publisher>> GetAsync(AuthorPublisherParams parametrs, CancellationToken ct = default)
        {
            var entities = _dbContext.Publishers.Where(x => x.Name.Contains(parametrs.MatchString));

            if (parametrs.OrderyBy == "abc")
            {
                entities.OrderBy(x => x.Name);
            }
            else
            {
                entities.OrderByDescending(x => x.Name);
            }

            return entities;
        }
    }
}
