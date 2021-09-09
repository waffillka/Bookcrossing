using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BookcrossingDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<Publisher> GetById(Guid id)
        {
            var entity = _dbContext.Publishers.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            return entity;
        }

        public async Task<IQueryable<Publisher>> GetByName(string name)
        {
            var authors = _dbContext.Publishers.Where(x => x.Name.Contains(name) && !x.IsDeleted);
            return authors;
        }
    }
}
