using System.Data;

namespace Infrastructure.DAL.Connection
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
        IDbConnection GetConnection();
    }
}