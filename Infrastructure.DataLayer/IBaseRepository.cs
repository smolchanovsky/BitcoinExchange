using System.Collections.Generic;
using Infrastructure.Common;

namespace Infrastructure.DataLayer
{
    public interface IBaseRepository<TDomain> where TDomain : IEntity
    {
        IList<TDomain> GetAll();
        TDomain GetById(long id);
        long Insert(TDomain domain);
        void BulkInsert(IEnumerable<TDomain> domains);
        bool Update(TDomain domain);
        bool Delete(long id);
    }
}