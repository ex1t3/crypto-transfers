using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbRepository
{
    public interface IDbFactory : IDisposable
    {
        IslbDbContext Get();
    }

    public class DbFactory : IDbFactory
    {
        private IslbDbContext _dbContext;

        public IslbDbContext Get()
        {
            return _dbContext ?? (_dbContext = new IslbDbContext());
        }

        private bool _isDisposed;

        ~DbFactory()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        protected void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
