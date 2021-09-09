using Bookcrossing.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        Task<IQueryable<Author>> GetByName(string name);
        Task<Author> GetById(Guid id);
    }
}
