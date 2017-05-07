using System;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Services
{
    public interface IServiceBase<T> //: IDisposable
        where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        T GetById(object id);
        IEnumerable<T> GetAll();
    }
}