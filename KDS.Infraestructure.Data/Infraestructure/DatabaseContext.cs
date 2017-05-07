using KDS.Infraestructure.Data.Entities;

namespace KDS.Infraestructure.Data
{
    public class DatabaseContext : Disposable, IDatabaseContext
    {
        private MainModelContext dataContext;
        public MainModelContext Get()
        {
            return dataContext ?? (dataContext = new MainModelContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
