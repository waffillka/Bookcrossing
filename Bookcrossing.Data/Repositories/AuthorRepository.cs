using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(BookcrossingDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IQueryable<Author>> GetAsync(AuthorPublisherParams parameters, CancellationToken ct = default)
        {
            var entities = _dbContext.Authors.Where(x => x.Name.Contains(parameters.MatchString));

            if (parameters.OrderyBy == "abc")
            {
                entities.OrderBy(x => x.Name);
            }
            else
            {
                entities.OrderByDescending(x => x.Name);
            }

            return entities.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);
        }
    }
}
