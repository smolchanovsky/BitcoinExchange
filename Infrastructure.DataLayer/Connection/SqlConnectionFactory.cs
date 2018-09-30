using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.DataLayer.Connection
{
    /// <summary>
    /// Base class for SQL connection factory.
    /// </summary>
    public abstract class SqlConnectionFactory : ConnectionFactory
    {
        protected string ConnectionString;

        protected SqlConnectionFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override IDbConnection Create()
        {
            return Connection = new SqlConnection(ConnectionString);
        }
    }
}
