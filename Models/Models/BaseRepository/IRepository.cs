using Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Models.BaseRepository
{
    public interface IRepository
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void AddRange<TEntity>(List<TEntity> entities) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> AsQueryable<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : class;
        IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : class;
        Task<List<TEntity>> FindAllAsnyc<TEntity>() where TEntity : class;
        Task<List<TEntity>> FindAllAsnyc<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : class;
        Task<List<TEntity>> FindAllAscAsnyc<TEntity, Tkey>(Expression<Func<TEntity, bool>> where = null,
            Expression<Func<TEntity, Tkey>> orderSelector = null
            ) where TEntity : class, Tkey;

        Task<List<TEntity>> FindAllDescAsnyc<TEntity, Tkey>(Expression<Func<TEntity, bool>> where = null,
            Expression<Func<TEntity, Tkey>> orderSelector = null) where TEntity : class, Tkey;

        Task<Pagination<TEntity>> FindPageAsnyc<TEntity>(int pageIndex, int pageSize,
            Expression<Func<TEntity, bool>> where = null) where TEntity : class;

        Task<List<TEntity>> FindAllForPageAsnyc<TEntity>(int pageIndex, int pageSize, 
            Expression<Func<TEntity, bool>> where = null) where TEntity : class;


        Task<TEntity> FindAsnyc<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : class;
        Task<TEntity> FindAsnyc<TEntity, Tkey>(Tkey id) where TEntity : class, Tkey;
        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> where = null) where TEntity : class;
        Task SaveChangesAsync();
    }
}
