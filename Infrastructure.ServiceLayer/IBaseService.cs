using Infrastructure.Common;
using System.Collections.Generic;

namespace Infrastructure.ServiceLayer
{
    public interface IBaseService<TDto> where TDto : IEntity
    {
        IList<TDto> GetAll();
        TDto GetById(long id);
        TDto Insert(TDto dto);
        bool Update(TDto dto);
        bool Delete(long id);
    }
}