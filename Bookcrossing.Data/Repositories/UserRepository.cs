using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;

namespace Bookcrossing.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(BookcrossingDbContext dbContext)
           : base(dbContext)
        {

        }
    }
}
