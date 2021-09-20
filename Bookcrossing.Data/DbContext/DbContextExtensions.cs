using Bookcrossing.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bookcrossing.Data.DbContext
{
    public static class DbContextExtensions
    {
        public static void RegisterSoftDeleteQueryFilter(this ModelBuilder modelBuilder, ICollection<Type> excludedTypes = null)
        {
            IEnumerable<IMutableEntityType> entityTypes = modelBuilder.Model.GetEntityTypes()
                                                                      .Where(t => !(excludedTypes ?? new List<Type>()).Contains(t.ClrType))
                                                                      .ToList();

            foreach (var entityType in entityTypes)
            {
                if (typeof(ISoftDeleteable).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
        }
        private static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
        {
            var methodToCall = typeof(DbContextExtensions).GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                                                          .MakeGenericMethod(entityData.ClrType);

            var filter = methodToCall.Invoke(null, new object[] { });
            entityData.SetQueryFilter((LambdaExpression)filter);
            entityData.AddIndex(entityData.FindProperty(nameof(ISoftDeleteable.IsDeleted)));
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>()
            where TEntity : class, ISoftDeleteable
        {
            Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
            return filter;
        }
    }
}
