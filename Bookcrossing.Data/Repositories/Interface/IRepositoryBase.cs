using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IRepositoryBase<TEntity>
        where TEntity : IIdentifiable<Guid>, ISoftDeleteable
    {
        Task<TEntity> GetAsync(Guid id, CancellationToken ct = default);
        Task<IQueryable<TEntity>> GetAsync(RequestFeatures pagination, CancellationToken ct = default);
        Task<TEntity> InsertAsync(TEntity newEntity, CancellationToken ct = default);
        Task InsertAsync(TEntity[] newEntity, CancellationToken ct = default);
        Task<TEntity> UpdateAsync(TEntity entityToUpdate, CancellationToken ct = default)
        Task Delete(TEntity entityToRemove, bool hard, CancellationToken ct = default);
        Task Delete(TEntity[] entityToRemove, bool hard, CancellationToken ct = default);
        Task<IQueryable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression, RequestFeatures parameters, CancellationToken ct = default);
        Task<TEntity> GetOneByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default);
        Task<int> SaveAsync(CancellationToken ct = default);
    }
}
