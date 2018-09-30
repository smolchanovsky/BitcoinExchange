using System.Collections.Generic;
using Infrastructure.Common;
using Infrastructure.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.WebApi
{
	public class BaseController<T> : Controller where T: IEntity
    {
        private readonly IBaseService<T> _baseService;

        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IList<T> GetAll(int id)
        {
            return _baseService.GetAll();
        }

        [HttpGet("{id}")]
        public T Get(long id)
        {
            return _baseService.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]T value)
        {
            _baseService.Insert(value);
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody]T value)
        {
            _baseService.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _baseService.Delete(id);
        }
    }
}
