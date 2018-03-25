using System.Collections.Generic;
using Infrastructure.Common;

namespace Infrastructure.BLL
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