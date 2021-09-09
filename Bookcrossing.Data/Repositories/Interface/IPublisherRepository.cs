using Bookcrossing.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IPublisherRepository : IRepositoryBase<Publisher>
    {
        Task<IQueryable<Publisher>> GetByName(string name);
        Task<Publisher> GetById(Guid id);
    }
}
