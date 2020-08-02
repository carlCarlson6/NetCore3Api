using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context) => this.Context = context;
        
        #region IRepository
        public async Task AddAsync(TEntity entity)
        {
            await this.Context.Set<TEntity>().AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.Context.Set<TEntity>().AddRangeAsync(entities);
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.Context.Set<TEntity>().ToListAsync();
        }
        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            return this.Context.Set<TEntity>().FindAsync(id);
        }
        public void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().RemoveRange(entities);
        }
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
        #endregion

    }
}
