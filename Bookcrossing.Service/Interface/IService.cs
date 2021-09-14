using Bookcrossing.Data.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Service.Interface
{
    public interface IService<TEntity> where TEntity : IIdentifiable<Guid>
    {
        Task<TEntity> GetAsync(Guid id, CancellationToken ct = default);
        Task<TEntity> InsertAsync(TEntity newEntity, CancellationToken ct = default);
        Task<TEntity> UpdateAsync(TEntity entityToUpdate, CancellationToken ct = default);
        Task<TEntity> DeleteAsync(TEntity entityToRemove, CancellationToken ct = default);
    }
}
