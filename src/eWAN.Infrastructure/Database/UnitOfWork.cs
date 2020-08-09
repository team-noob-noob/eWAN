using System;
using System.Threading.Tasks;
using eWAN.Application.Services;

namespace eWAN.Infrastructure.Database
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EwanContext _context;
        private bool _disposed;

        public UnitOfWork(EwanContext context) => this._context = context;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(!this._disposed)
            {
                if(disposing)
                {
                    this._context.Dispose();
                }
            }

            this._disposed = true;
        }

        public async Task<int> Save()
        {
            int affectedRows = await this._context
                .SaveChangesAsync()
                .ConfigureAwait(false);
            return affectedRows;
        }
    }
}
