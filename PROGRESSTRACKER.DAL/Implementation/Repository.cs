using Microsoft.EntityFrameworkCore;
using PROGRESSTRACKER.DAL.Interface;
using PROGRESSTRACKER.DATACONTEXT;
using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.DAL.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly Context context;
        private DbSet<T> entities;
        public Repository(Context context)
        {
            this.context = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            entities = context.Set<T>();
        }

        public async Task Delete(T entity)
        {
            entity.IsDeleted = true;
            entities.Update(entity);
            await context.SaveChangesAsync();
        }

        public List<T> FindAllByCondition(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public IQueryable<T> FindAllByConditionWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = entities.Where(predicate);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IQueryable<T> FindAllWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            var query = entities.AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public T FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().SingleOrDefault(predicate);
        }

        public T FindByConditionWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = entities.Where(predicate);
            var result = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (!result.Any())
                return null;

            return result.First();
        }

        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public async Task<T> Insert(T entity)
        {
            entities.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task Update(T entity)
        {
            entities.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
