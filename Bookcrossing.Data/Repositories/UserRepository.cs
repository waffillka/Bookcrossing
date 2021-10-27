using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(BookcrossingDbContext dbContext)
           : base(dbContext)
        { }

        public async Task<User> GetByAuthIdAsync(Guid id, CancellationToken ct)
        {
            var entity = await DbContext.Users.FirstOrDefaultAsync(x => x.UserAuthId == id, ct);
            return entity;
        }


    }
}
