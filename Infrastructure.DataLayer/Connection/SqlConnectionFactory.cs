using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.DataLayer.Connection
{
    /// <summary>
    /// SQL connection factory.
    /// </summary>
    public class SqlConnectionFactory : ConnectionFactory
    {
        protected string ConnectionString;

        public SqlConnectionFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override IDbConnection Create()
        {
            return Connection = new SqlConnection(ConnectionString);
        }
    }
}
