using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Interfaces;
using Bookcrossing.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class, IIdentifiable<Guid>, ISoftDeleteable
    {
        protected BookcrossingDbContext DbContext { get; }

        public RepositoryBase(BookcrossingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task Delete(TEntity entityToRemove, CancellationToken ct = default, bool hard = false)
        {
            if (hard)
            {
                DbContext.Set<TEntity>().Remove(entityToRemove);
            }
            else
            {
                if (DbContext.Entry(entityToRemove).State == EntityState.Detached)
                {
                    DbContext.Set<TEntity>().Attach(entityToRemove);
                }

                entityToRemove.IsDeleted = true;
            }

            SaveAsync(ct);
        }

        public async Task Delete(TEntity[] entitiesToRemove, CancellationToken ct = default, bool hard = false)
        {
            if (hard)
            {
                DbContext.Set<TEntity>().RemoveRange(entitiesToRemove);
            }
            else
            {
                foreach (var item in entitiesToRemove)
                {
                    if (DbContext.Entry(item).State == EntityState.Detached)
                    {
                        DbContext.Set<TEntity>().Attach(item);
                    }

                    item.IsDeleted = true;
                }
            }

            SaveAsync(ct);
        }

        public async Task<TEntity> GetAsync(Guid id, CancellationToken ct = default)
        {
            var entity = DbContext.Set<TEntity>().FindAsync(id, ct);

            return entity.Result;
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAsync(RequestFeatures pagination, CancellationToken ct = default)
        {
            if (pagination == null)
            {
                throw new ArgumentNullException(nameof(pagination));
            }

            var entities = DbContext.Set<TEntity>().Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);

            return await entities.ToListAsync(ct).ConfigureAwait(false);
        }

        public async Task<TEntity> InsertAsync(TEntity newEntity, CancellationToken ct = default)
        {
            var entity = DbContext.Set<TEntity>().AddAsync(newEntity, ct);
            SaveAsync(ct);

            return entity.Result.Entity;
        }

        public async Task InsertAsync(TEntity[] newEntity, CancellationToken ct = default)
        {
            DbContext.Set<TEntity>().AddRangeAsync(newEntity, ct);
            SaveAsync(ct);
        }

        public async Task<TEntity> UpdateAsync(TEntity entityToUpdate, CancellationToken ct = default)
        {
            var entity = DbContext.Set<TEntity>().Update(entityToUpdate);
            SaveAsync(ct);

            return entity.Entity;
        }

        public async Task<IReadOnlyCollection<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression, RequestFeatures parameters, CancellationToken ct = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return await DbContext.Set<TEntity>()
                .Where(expression)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync(ct).ConfigureAwait(false);
        }


        public async Task<TEntity> GetOneByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct = default) =>
            DbContext.Set<TEntity>().FirstOrDefaultAsync(expression, ct).Result;

        public Task<int> SaveAsync(CancellationToken ct = default)
        {
            return DbContext.SaveChangesAsync(ct);
        }
    }
}
