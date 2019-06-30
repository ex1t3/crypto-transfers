using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DAL.DbRepository
{
    public interface IDbRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        TEntity GetById(long id);
    }

    public class DbRepository<TEntity> : IDbRepository<TEntity> where TEntity : class
    {
        private IslbDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        protected IDbFactory DbFactory { get; }
        protected IslbDbContext DataSet => _dbContext ?? (_dbContext = DbFactory.Get());

        public DbRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DataSet.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> @where)
        {
            IEnumerable<TEntity> entities = _dbSet.Where(where).AsEnumerable();
            foreach (var entity in entities)
            {
                _dbSet.Remove(entity);
            }

            _dbContext.SaveChanges();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> @where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> @where)
        {
            return _dbSet.Where(where).ToList();
        }

        public virtual TEntity GetById(long id)
        {
            return _dbSet.Find(id);
        }
    }
}
