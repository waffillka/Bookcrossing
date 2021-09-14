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
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BookcrossingDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IQueryable<Book>> GetAsync(BookParams parameters, CancellationToken ct = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            IQueryable<Book> entities = _dbContext.Books;

            if (!string.IsNullOrWhiteSpace(parameters.SearchString))
            {
                entities = entities.Where(x => x.Name.Contains(parameters.SearchString)
                                                || x.Description.Contains(parameters.SearchString)
                                                || x.Authors.Any(c => c.Name.Contains(parameters.SearchString)) // что-то похожее на 48 строке 
                                                || x.ISBIN.Contains(parameters.SearchString)
                                                || x.Publisher.Name.Contains(parameters.SearchString));
            }

            if (parameters.IsFree == true)
            {
                entities = entities.Where(x => x.RecipientId != null);
            }

            if (parameters.Authors != null)
            {
                entities = entities.Where(book => book.Authors.Any(x => parameters.Authors.Contains(x.Name)));
            }

            if (parameters.Publishers != null)
            {
                entities = entities.Where(book => parameters.Publishers.Contains(book.Publisher.Name));
            }

            entities = parameters.OrderyBy == Ordery.Asc ? entities.OrderBy(x => x.Name) : entities.OrderByDescending(x => x.Name);

            return entities.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);
        }
    }
}
