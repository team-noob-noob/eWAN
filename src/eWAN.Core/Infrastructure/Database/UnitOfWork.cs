using System;
using System.Threading.Tasks;
using eWAN.Core.Application.Services;

namespace eWAN.Core.Infrastructure.Database
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SchoolContext _context;
        private bool _disposed;

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public async Task<int> Save()
        {
            int affectedRows = await _context.SaveChangesAsync()
                .ConfigureAwait(false);
            
            return affectedRows;
        }
    }
}
