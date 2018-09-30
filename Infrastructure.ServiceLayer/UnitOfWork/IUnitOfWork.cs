using System;
using System.Data;

namespace Infrastructure.ServiceLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
    }
}