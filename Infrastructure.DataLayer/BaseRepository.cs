using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DapperExtensions;
using Infrastructure.Common;
using Infrastructure.DataLayer.Connection;

namespace Infrastructure.DataLayer
{
    /// <summary>
    /// The base  <a href="https://github.com/StackExchange/Dapper">Dapper</a> repository that implements a common functional.
    /// </summary>
    public class BaseRepository<TDomain> : IBaseRepository<TDomain> where TDomain : class, IEntity
    {
        private readonly IConnectionFactory _connectionFactory;
        private IDbConnection Connection => _connectionFactory.GetConnection();

        public BaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public virtual IList<TDomain> GetAll()
        {
            return (Connection as SqlConnection).GetList<TDomain>().ToList();
        }

        public virtual TDomain GetById(long id)
        {
            return (Connection as SqlConnection).Get<TDomain>(id);
        }

        public virtual long Insert(TDomain domain)
        {
            return (Connection as SqlConnection).Insert(domain);
        }

        public virtual void BulkInsert(IEnumerable<TDomain> domains)
        {
            (Connection as SqlConnection).Insert(domains);
        }

        public virtual bool Update(TDomain domain)
        {
            return (Connection as SqlConnection).Update(domain);
        }

        public virtual bool Delete(long id)
        {
            return (Connection as SqlConnection).Delete<TDomain>(id);
        }
    }
}
