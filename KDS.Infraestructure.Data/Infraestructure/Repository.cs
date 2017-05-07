using AutoMapper;
using KDS.Domain.Seedwork;
using KDS.Infraestructure.CrossCutting.Helpers;
using KDS.Infraestructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace KDS.Infraestructure.Data
{
    public class Repository<TDomain, TEntity> : IRepository<TDomain> 
        where TDomain : class where TEntity : class
    {
        #region Members

        private MainModelContext dataContext;
        private readonly IDbSet<TEntity> dbset;

        #endregion

        #region Constructor

        protected Repository(IDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
            dbset = DataContext.Set<TEntity>();
        }

        #endregion

        #region IRepository Members

        protected IDatabaseContext DatabaseContext
        {
            get;
            private set;
        }

        protected MainModelContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseContext.Get()); }
        }

        public virtual void Add(TDomain dtoEntity)
        {
            if (dtoEntity != null)
            {
                var entity = Mapper.Map<TDomain, TEntity>(dtoEntity);
                SetValue(ref entity, "EstadoRegistro", true);
                SetValue(ref entity, "UsuarioCreacion", AppContext.Sesion.UserName);
                SetValue(ref entity, "FechaCreacion", DateTime.Now);
                dbset.Add(entity);
            }       
        }

        public virtual void Update(TDomain dtoEntity)
        {
            try
            {
                if (dtoEntity != null)
                {
                    var entity = Mapper.Map<TDomain, TEntity>(dtoEntity);
                    SetValue(ref entity, "UsuarioModificacion", AppContext.Sesion.UserName);
                    SetValue(ref entity, "FechaModificacion", DateTime.Now);
                    dbset.Attach(entity);
                    dataContext.Entry(entity).State = EntityState.Modified;

                    //foreach (var entry in dataContext.ChangeTracker.Entries<TrackableEntity>())
                    //{
                    //    var ent = entry.Entity;
                    //    entry.State = EntityState.Unchanged;
                    //    ApplyPropertyChanges(entry.OriginalValues, ent.OriginalValues);
                    //}
                }
            }
            catch
            {
                throw;
            }            
        }

        //public virtual void Delete(object id)
        //{
        //    var entity = dbset.Find(id);
        //    dbset.Remove(entity);
        //}

        public virtual void Delete(object id)
        {
            if (id != null)
            {
                var entity = dbset.Find(id);
                SetValue(ref entity, "EstadoRegistro", false);
                SetValue(ref entity, "UsuarioModificacion", AppContext.Sesion.UserName);
                SetValue(ref entity, "FechaModificacion", DateTime.Now);
                dataContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual TDomain GetById(object id)
        {
            if (id != null) {
                var entity = dbset.Find(id);
                dataContext.Entry(entity).State = EntityState.Detached;
                return Mapper.Map<TEntity, TDomain>(entity);
            }
            else
                return null;
        }

        public virtual IEnumerable<TDomain> GetAll()
        {
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDomain>>(dbset);
        }

        #endregion

        #region Aplicaciones Auxiliares

        private static void SetValue(ref TEntity obj, string property, object value)
        {
            var propertyInfo = obj.GetType().GetProperty(property);
            var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
            var safeValue = (value == null) ? null : Convert.ChangeType(value, type);
            propertyInfo.SetValue(obj, safeValue, null);
        }

        //private static void ApplyPropertyChanges(DbPropertyValues values, Dictionary<string, object> originalValues)
        //{
        //    foreach (var originalValue in originalValues)
        //    {
        //        if (originalValue.Value is Dictionary<string, object>)
        //            ApplyPropertyChanges((DbPropertyValues)values[originalValue.Key], (Dictionary<string, object>)originalValue.Value);
        //        else
        //        {
        //            values[originalValue.Key] = originalValue.Value;
        //        }
        //    }
        //}

        #endregion
    }
}