using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Contracts.Enumeration;
using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<IReadOnlyCollection<Book>> GetAsync(BookParams parameters, CancellationToken ct = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            IQueryable<Book> entities = DbContext.Books;

            if (!string.IsNullOrWhiteSpace(parameters.SearchString))
            {
                entities = entities.Where(x => x.Name.Contains(parameters.SearchString)
                                                || x.Description.Contains(parameters.SearchString)
                                                || x.Authors.Any(c => c.Name.Contains(parameters.SearchString)) // что-то похожее на 48 строке 
                                                || x.ISBIN.Contains(parameters.SearchString)
                                                || x.Publisher.Name.Contains(parameters.SearchString));
            }

            if (parameters.IsFree)
            {
                entities = entities.Where(x => x.RecipientId != null);
            }

            if (parameters.Publishers != null)
            {
                entities = entities.Where(book => parameters.Publishers.Contains(book.Publisher.Name));
            }

            entities = parameters.OrderBy == Order.Asc ? entities.OrderBy(x => x.Name) : entities.OrderByDescending(x => x.Name);

            return await entities.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).ToListAsync(ct).ConfigureAwait(false);
        }
    }
}
