using System.Collections.Generic;

namespace KDS.Application.Interfaces
{
    public interface IAppServiceBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        T GetById(object id);
        IEnumerable<T> GetAll();
        //void Dispose();
    }
}
