using Infrastructure.DataLayer.Connection;

namespace BitcoinExchange.DataLayer
{
    /// <summary>
    /// Creates a connection to the SQL Server.
    /// </summary>
    public class SqlServerConnectionFactory : SqlConnectionFactory
    {
        public SqlServerConnectionFactory() : base(connectionString: @"")
        {
        }
    }
}
