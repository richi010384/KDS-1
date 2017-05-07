using System;
using System.Collections.Generic;

namespace KDS.Domain.Seedwork
{
    public interface IRepository<T> //: IDisposable
        where T : class
    {
        //IUnitOfWork UnitOfWork { get; }
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        T GetById(object id);
        IEnumerable<T> GetAll();
    }
}