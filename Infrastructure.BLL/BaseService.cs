using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Infrastructure.BLL.UnitOfWork;
using Infrastructure.Common;
using Infrastructure.DAL;

namespace Infrastructure.BLL
{
    /// <summary>
    /// The base service that implements a common functional.
    /// </summary>
    /// <typeparam name="TDto">Data transfer object</typeparam>
    /// <typeparam name="TDomain">Domain entity</typeparam>
    public class BaseService<TDto, TDomain> : IBaseService<TDto>
        where TDomain : IEntity
        where TDto : IEntity
    {
        protected readonly IUnitOfWorkFactory UnitOfWorkFactory;
        private readonly IBaseRepository<TDomain> _baseRepository;

        public BaseService(IUnitOfWorkFactory unitOfWorkFactory, IBaseRepository<TDomain> baseRepository)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            _baseRepository = baseRepository;
        }

        public virtual IList<TDto> GetAll()
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                return _baseRepository.GetAll()
                    .Select(x => Mapper.Map<TDto>(x))
                    .ToList();
            }
        }

        public virtual TDto GetById(long id)
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                return Mapper.Map<TDto>(_baseRepository.GetById(id));
            }
        }

        public virtual TDto Insert(TDto dto)
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                var domain = Mapper.Map<TDomain>(dto);
                domain.Id = _baseRepository.Insert(domain);
                return Mapper.Map<TDto>(domain);
            }
        }

        public virtual bool Update(TDto dto)
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                return _baseRepository.Update(Mapper.Map<TDomain>(dto));
            }
        }

        public virtual bool Delete(long id)
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                return _baseRepository.Delete(id);
            }
        }
    }
}
