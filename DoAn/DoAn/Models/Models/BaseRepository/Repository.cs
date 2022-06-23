using Models.EF;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models.BaseRepository
{
    public class Repository : IRepository
    {
        private readonly DB_Relief _dbContext = new DB_Relief();

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange<TEntity>(List<TEntity> entities) where TEntity : class
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> AsQueryable<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : class
        {
            return _dbContext.Set<TEntity>().Where(where);
        }

        public IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>();
        }

        public Task<List<TEntity>> FindAllAsnyc<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public Task<List<TEntity>> FindAllAsnyc<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : class
        {
            return _dbContext.Set<TEntity>().Where(where).AsNoTracking().ToListAsync();
        }

        public Task<List<TEntity>> FindAllAscAsnyc<TEntity, Tkey>(Expression<Func<TEntity, bool>> where = null,
            Expression<Func<TEntity, Tkey>> orderSelector = null
            ) where TEntity : class, Tkey
        {
            return _dbContext.Set<TEntity>().Where(where).OrderBy(orderSelector).AsNoTracking().ToListAsync();
        }

        public Task<List<TEntity>> FindAllDescAsnyc<TEntity, Tkey>(Expression<Func<TEntity, bool>> where = null,
            Expression<Func<TEntity, Tkey>> orderSelector = null) where TEntity : class, Tkey
        {
            return _dbContext.Set<TEntity>().Where(where).OrderByDescending(orderSelector).AsNoTracking().ToListAsync();
        }

        public Task<TEntity> FindAsnyc<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : class
        {
            return _dbContext.Set<TEntity>().FirstOrDefaultAsync(where);
        }

        public Task<TEntity> FindAsnyc<TEntity, Tkey>(Tkey id) where TEntity : class, Tkey
        {
            return _dbContext.Set<TEntity>().FindAsync(id);
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }


    }
}
