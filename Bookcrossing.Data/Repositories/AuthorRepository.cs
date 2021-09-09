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
            :base(dbContext)
        {
            
        }

        public async Task<Author> GetById(Guid id)
        {
            var entity = _dbContext.Authors.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            return entity;
        }

        public async Task<IQueryable<Author>> GetByName(string name)
        {
            var authors = _dbContext.Authors.Where(x => x.Name.Contains(name) && !x.IsDeleted);
            return authors;
        }
    }
}
