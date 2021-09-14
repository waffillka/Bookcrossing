using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.Enumeration;
using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;
using System;
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
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var entities = _dbContext.Authors.Where(x => x.Name.Contains(parameters.SearchString));

            entities = parameters.OrderyBy == Ordery.Asc ? entities.OrderBy(x => x.Name) : entities.OrderByDescending(x => x.Name);

            return entities.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);
        }
    }
}
