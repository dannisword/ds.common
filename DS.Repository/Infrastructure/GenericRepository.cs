using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DS.Repository.Infrastructure;

namespace DS.Repository.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbContext context;
        public GenericRepository(DbContext context)
        {
            this.context = context;
        }
        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            
            return await this.context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.Set<TEntity>().Add(entity);
        }
        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.Entry(entity).State = EntityState.Deleted;
        }
        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.Entry(entity).State = EntityState.Modified;
        }
        
    }
}