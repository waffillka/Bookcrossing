using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IRepositoryBase<TEntity>
        where TEntity : IIdentifiable<Guid>, ISoftDeleteable
    {
        Task<TEntity> GetAsync(Guid id, CancellationToken ct = default);
        Task<IQueryable<TEntity>> GetAsync(RequestFeatures pagination);
        Task<TEntity> InsertAsync(TEntity newEntity, CancellationToken ct = default);
        TEntity Update(TEntity entityToUpdate);
        Task DeleteAsync(TEntity entityToRemove);
    }
}
