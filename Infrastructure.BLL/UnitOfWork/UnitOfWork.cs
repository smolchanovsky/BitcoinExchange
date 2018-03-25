using System;
using System.Data;

namespace Infrastructure.BLL.UnitOfWork
{
    /// <summary>
    /// A very simple unit of work.
    /// </summary>
    //TODO: Implement methods: commit, rollback, etc.
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        public IDbConnection Connection { get; }

        public UnitOfWork(IDbConnection connection)
        {
            Connection = connection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Connection.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
