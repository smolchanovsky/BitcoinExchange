using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public BaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public virtual IList<TDomain> GetAll()
        {
            return GetConnection().GetList<TDomain>().ToList();
        }

        public virtual TDomain GetById(long id)
        {
            return GetConnection().Get<TDomain>(id);
        }

        public virtual long Insert(TDomain domain)
        {
            return GetConnection().Insert(domain);
        }

        public virtual void BulkInsert(IEnumerable<TDomain> domains)
        {
            GetConnection().Insert(domains);
        }

        public virtual bool Update(TDomain domain)
        {
            return GetConnection().Update(domain);
        }

        public virtual bool Delete(long id)
        {
            return GetConnection().Delete<TDomain>(id);
        }

	    private DbConnection GetConnection() => 
		    _connectionFactory.GetConnection() as DbConnection ?? throw new InvalidOperationException();
	}
}
