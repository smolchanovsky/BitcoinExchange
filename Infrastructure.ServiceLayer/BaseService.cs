using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Infrastructure.Common;
using Infrastructure.DataLayer;
using Infrastructure.ServiceLayer.UnitOfWork;

namespace Infrastructure.ServiceLayer
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
	    protected readonly IMapper ModelMapper;
		private readonly IBaseRepository<TDomain> _baseRepository;

	    public BaseService(IUnitOfWorkFactory unitOfWorkFactory, IBaseRepository<TDomain> baseRepository, IMapper modelMapper)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            _baseRepository = baseRepository;
	        ModelMapper = modelMapper;
        }

        public virtual IList<TDto> GetAll()
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                return _baseRepository.GetAll()
                    .Select(x => ModelMapper.Map<TDto>(x))
                    .ToList();
            }
        }

        public virtual TDto GetById(long id)
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                return ModelMapper.Map<TDto>(_baseRepository.GetById(id));
            }
        }

        public virtual TDto Insert(TDto dto)
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                var domain = ModelMapper.Map<TDomain>(dto);
                domain.Id = _baseRepository.Insert(domain);
                return ModelMapper.Map<TDto>(domain);
            }
        }

        public virtual bool Update(TDto dto)
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                return _baseRepository.Update(ModelMapper.Map<TDomain>(dto));
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
