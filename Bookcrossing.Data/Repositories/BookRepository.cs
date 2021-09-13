using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
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
            IQueryable<Book> entities = _dbContext.Books;

            parameters ??= new BookParams();

            if (string.IsNullOrEmpty(parameters.MatchString))
            {
                entities = entities.Where(x => x.Name.Contains(parameters.MatchString));
            }

            if (parameters.OrderyBy == "abc")
            {
                entities.OrderBy(x => x.Name);
            }
            else
            {
                entities.OrderByDescending(x => x.Name);
            }

            if (parameters.IsFree)
            {
                entities = entities.Where(x => x.RecipientId != null);
            }
            else
            {
                entities = entities.Where(x => x.RecipientId == null);
            }

            if (parameters.Authors != null)
            {
                entities = entities.Where(book => book.Authors.Any(x => parameters.Authors.Contains(x.Name)));
            }
            if (parameters.Publishers != null)
            {
                entities = entities.Where(book => parameters.Publishers.Contains(book.Publisher.Name));
            }

            return entities.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);
        }
    }
}
