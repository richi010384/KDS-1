using KDS.Infraestructure.Data.Entities;
using KDS.Infrastructure.Data.Seedwork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace KDS.Infraestructure.Data.UnitOfWork
{
    public class MainUnitOfWork
        : DbContext, IQueryableUnitOfWork
    {
        //private readonly IDatabaseContext _databaseContext;
        //private bool _disposed = false;

        //public MainUnitOfWork(IDatabaseContext databaseContext)
        //{
        //    _databaseContext = databaseContext;
        //}

        #region IDbSet Members

        //IDbSet<Product> _products;
        //public IDbSet<Product> Products
        //{
        //    get
        //    {
        //        if (_products == null)
        //            _products = base.Set<Product>();

        //        return _products;
        //    }
        //}

        #endregion

        #region IQueryableUnitOfWork Members

        public DbSet<T> CreateSet<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public void Attach<T>(T entity)
            where T : class
        {
            base.Entry(entity).State = EntityState.Unchanged;
        }

        public void SetModified<T>(T entity)
            where T : class
        {
            base.Entry(entity).State = EntityState.Modified;
        }
        public void ApplyCurrentValues<T>(T original, T current)
            where T : class
        {
            base.Entry(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;
            do
            {
                try
                {
                    base.SaveChanges();
                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });
                }
            } while (saveFailed);
        }

        public void Rollback()
        {
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public IEnumerable<T> ExecuteQuery<T>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<T>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion
    }
}
