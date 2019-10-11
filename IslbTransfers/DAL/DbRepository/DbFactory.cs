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
        private bool _isDisposed;
        private IslbDbContext _context;
        ~DbFactory()
        {
            Dispose(false);
        }

        public IslbDbContext Get()
        {
            _context = new IslbDbContext();
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            return _context;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        protected void DisposeCore()
        {
            _context?.Dispose();
        }
    }
}
