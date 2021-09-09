using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Interfaces;
using Bookcrossing.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task DeleteAsync(TEntity entityToRemove)
        {
            _dbContext.Set<TEntity>().Remove(entityToRemove);
        }

        public async Task<TEntity> GetAsync(Guid id, CancellationToken ct = default)
        {
            var entity = _dbContext.Set<TEntity>().FindAsync(id, ct);
            return entity.Result;
        }

        public async Task<IQueryable<TEntity>> GetAsync(RequestFeatures pagination)
        {
            var entities = _dbContext.Set<TEntity>().Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);
            return entities;
        }

        public async Task<TEntity> InsertAsync(TEntity newEntity, CancellationToken ct = default)
        {
            var entity = _dbContext.Set<TEntity>().AddAsync(newEntity, ct);
            return entity.Result.Entity;
        }

        public TEntity Update(TEntity entityToUpdate)
        {
            var entity = _dbContext.Set<TEntity>().Update(entityToUpdate);
            return entity.Entity;
        }
    }
}
