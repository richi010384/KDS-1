using KDS.Domain.Interfaces.Services;
using KDS.Domain.Seedwork;
using System.Collections.Generic;

namespace KDS.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> 
        where T : class
    {
        private readonly IRepository<T> _repository;

        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(object id)
        {
            _repository.Delete(id);
        }

        public T GetById(object id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        //#region IDisposable Members

        //public void Dispose()
        //{
        //    if (_repository != null)
        //        _repository.Dispose();
        //}

        //#endregion
    }
}
