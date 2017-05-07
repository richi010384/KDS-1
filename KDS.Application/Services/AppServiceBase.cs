using KDS.Application.Interfaces;
using KDS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace KDS.Application.Services
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class /*IDisposable,*/
    {
        private readonly IServiceBase<T> _appServiceBase;

        public AppServiceBase(IServiceBase<T> appServiceBase)
        {
            _appServiceBase = appServiceBase;
        }

        public void Add(T entity)
        {
            _appServiceBase.Add(entity);
        }

        public void Update(T entity)
        {
            _appServiceBase.Update(entity);
        }

        public void Delete(object id)
        {
            _appServiceBase.Delete(id);
        }

        public T GetById(object id)
        {
            return _appServiceBase.GetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _appServiceBase.GetAll();
        }

        //public void Dispose()
        //{
        //    _serviceBase.Dispose();
        //}
    }
}
