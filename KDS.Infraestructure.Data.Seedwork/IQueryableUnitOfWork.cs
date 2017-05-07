using System.Data.Entity;
using KDS.Domain.Seedwork;

namespace KDS.Infrastructure.Data.Seedwork
{
    public interface IQueryableUnitOfWork
        :IUnitOfWork, ISql
    {
        DbSet<T> CreateSet<T>() where T : class;

        void Attach<T>(T entity) where T : class;

        void SetModified<T>(T entity) where T : class;

        void ApplyCurrentValues<T>(T original, T current) where T : class;
    }
}
