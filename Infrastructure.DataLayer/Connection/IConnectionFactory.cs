using System.Data;

namespace Infrastructure.DataLayer.Connection
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
        IDbConnection GetConnection();
    }
}