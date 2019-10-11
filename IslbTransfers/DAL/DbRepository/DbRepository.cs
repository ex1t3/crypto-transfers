using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DAL.DbRepository
{
    public interface IDbRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);
        TEntity GetById(long id);
    }

    public class DbRepository<TEntity> : IDbRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        private IDbFactory DbFactory { get; }
        private readonly IslbDbContext _dbContext;

        public DbRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbContext = dbFactory.Get();
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> @where)
        {
            var entities = _dbSet.Where(where).AsEnumerable();
            foreach (var entity in entities)
            {
                _dbSet.Remove(entity);
            }

            _dbContext.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> @where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> @where)
        {
            return await _dbSet.Where(where).FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> @where)
        {
            return _dbSet.Where(where).ToList();
        }

        public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> @where)
        {
            return await _dbSet.Where(where).ToListAsync();
        }

        public TEntity GetById(long id)
        {
            return _dbSet.Find(id);
        }
    }
}
