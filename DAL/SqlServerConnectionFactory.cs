using Infrastructure.DAL.Connection;

namespace DAL
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
