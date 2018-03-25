using System;
using System.Data;

namespace Infrastructure.BLL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
    }
}