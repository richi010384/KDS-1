using System;
using KDS.Domain.Seedwork;
using KDS.Infraestructure.Data.Entities;
using System.Data.Entity.Validation;
using System.Linq;

namespace KDS.Infraestructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext databaseContext;
        private MainModelContext dataContext;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        protected MainModelContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseContext.Get()); }
        }

        public void Commit()
        {
            try
            {
                DataContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }

        #endregion
    }
}
