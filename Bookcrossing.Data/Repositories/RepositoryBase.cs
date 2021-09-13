using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Interfaces;
using Bookcrossing.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class, IIdentifiable<Guid>, ISoftDeleteable
    {
        protected readonly BookcrossingDbContext _dbContext;

        public RepositoryBase(BookcrossingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(TEntity entityToRemove, bool hard, CancellationToken ct = default)
        {
            if (hard)
            {
                _dbContext.Set<TEntity>().Remove(entityToRemove);
            }
            else
            {
                if (_dbContext.Entry(entityToRemove).State == EntityState.Detached)
                {
                    _dbContext.Set<TEntity>().Attach(entityToRemove);
                }

                entityToRemove.IsDeleted = true;
            }
        }

        public async Task Delete(TEntity[] entitiesToRemove, bool hard, CancellationToken ct = default)
        {
            if (hard)
            {
                _dbContext.Set<TEntity>().RemoveRange(entitiesToRemove);
            }
            else
            {
                foreach (var item in entitiesToRemove)
                {
                    if (_dbContext.Entry(item).State == EntityState.Detached)
                    {
                        _dbContext.Set<TEntity>().Attach(item);
                    }

                    item.IsDeleted = true;
                }
            }
        }

        public async Task<TEntity> GetAsync(Guid id, CancellationToken ct = default)
        {
            var entity = _dbContext.Set<TEntity>().FindAsync(id, ct);
            return entity.Result;
        }

        public virtual async Task<IQueryable<TEntity>> GetAsync(RequestFeatures pagination, CancellationToken ct = default)
        {
            var entities = _dbContext.Set<TEntity>().Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);
            return entities;
        }

        public async Task<TEntity> InsertAsync(TEntity newEntity, CancellationToken ct = default)
        {
            var entity = _dbContext.Set<TEntity>().AddAsync(newEntity, ct);
            return entity.Result.Entity;
        }

        public async Task InsertAsync(TEntity[] newEntity, CancellationToken ct = default)
        {
            _dbContext.Set<TEntity>().AddRangeAsync(newEntity, ct);
        }

        public TEntity Update(TEntity entityToUpdate)
        {
            var entity = _dbContext.Set<TEntity>().Update(entityToUpdate);
            return entity.Entity;
        }

        public async Task<IQueryable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression, RequestFeatures parameters, CancellationToken ct = default) =>
            _dbContext.Set<TEntity>()
                .Where(expression)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

        public async Task<TEntity> GetOneByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default) =>
            _dbContext.Set<TEntity>().FirstOrDefaultAsync(expression, ct).Result;
    }
}
