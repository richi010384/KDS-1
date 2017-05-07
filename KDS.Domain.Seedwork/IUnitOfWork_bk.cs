using System;

namespace KDS.Domain.Seedwork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void CommitAndRefreshChanges();
        
        void Rollback();
    }
}