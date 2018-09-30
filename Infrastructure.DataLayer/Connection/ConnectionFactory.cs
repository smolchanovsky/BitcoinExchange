using System;
using System.Data;

namespace Infrastructure.DataLayer.Connection
{
    /// <summary>
    /// Base class for connection factory.
    /// </summary>
    // TODO: Implement custom interface that won't be bound to a specific type of connection and replace IDbConnection to it.
    public abstract class ConnectionFactory : IConnectionFactory
    {
        protected static IDbConnection Connection;

        public abstract IDbConnection Create();

        public IDbConnection GetConnection()
        {
            if (Connection == null)
                throw new InvalidOperationException("Connection not created.");
            return Connection;
        }
    }
}
