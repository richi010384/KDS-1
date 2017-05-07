using AutoMapper;
using KDS.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace KDS.Infrastructure.Data.Seedwork
{
    public class Repository<TDomain, TEntity> : IRepository<TDomain> 
        where TDomain : class where TEntity : class
    {
        #region Members

        IQueryableUnitOfWork _unitOfWork;
       
        #endregion

        #region Constructor

        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository Members

        public IUnitOfWork UnitOfWork
        {
            get 
            {
                return _unitOfWork;
            }
        }

        public virtual void Add(TDomain dtoEntity)
        {
            if (dtoEntity != null)
            {
                var entity = Mapper.Map<TDomain, TEntity>(dtoEntity);
                GetSet().Add(entity);
            }
            //else
            //{
            //    LoggerFactory.CreateLog()
            //              .LogInfo(Messages.info_CannotAddNullEntity,typeof(TEntity).ToString());
                
            //}            
        }

        public virtual void Update(TDomain dtoEntity)
        {
            if (dtoEntity != null)
            {
                var entity = Mapper.Map<TDomain, TEntity>(dtoEntity);
                _unitOfWork.SetModified(entity);
            }
            //else
            //{
            //    LoggerFactory.CreateLog()
            //              .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            //}
        }

        public virtual void Delete(TDomain dtoEntity)
        {
            if (dtoEntity != null)
            {
                var entity = Mapper.Map<TDomain, TEntity>(dtoEntity);
                _unitOfWork.Attach(entity);
                GetSet().Remove(entity);
            }
            //else
            //{
            //    LoggerFactory.CreateLog()
            //              .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            //}
        }

        public virtual void Delete(object id)
        {
            TDomain dtoEntity = GetById(id);
            Delete(dtoEntity);
        }

        //public virtual void TrackItem(TEntity item)
        //{
        //    if (item != (TEntity)null)
        //        _UnitOfWork.Attach<TEntity>(item);
        //    //else
        //    //{
        //    //    LoggerFactory.CreateLog()
        //    //              .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
        //    //}
        //}

        public virtual TDomain GetById(object id)
        {
            if (id != null)
                return Mapper.Map<TEntity, TDomain>(GetSet().Find(id));
            else
                return null;
        }

        public virtual IEnumerable<TDomain> GetAll()
        {
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDomain>>(GetSet());
        }

        //public virtual IEnumerable<TEntity> AllMatching(Domain.Seedwork.Specification.ISpecification<TEntity> specification)
        //{
        //    return GetSet().Where(specification.SatisfiedBy());
        //}

        //public virtual IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        //{
        //    var set = GetSet();

        //    if (ascending)
        //    {
        //        return set.OrderBy(orderByExpression)
        //                  .Skip(pageCount * pageIndex)
        //                  .Take(pageCount);
        //    }
        //    else
        //    {
        //        return set.OrderByDescending(orderByExpression)
        //                  .Skip(pageCount * pageIndex)
        //                  .Take(pageCount);
        //    }
        //}

        //public virtual IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        //{
        //    return GetSet().Where(filter);
        //}

        //public virtual void Merge(TEntity persisted, TEntity current)
        //{
        //    _UnitOfWork.ApplyCurrentValues(persisted, current);
        //}

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_unitOfWork != null)
                _unitOfWork.Dispose();
        }

        #endregion

        #region Private Methods

        IDbSet<TEntity> GetSet()
        {
            var a = _unitOfWork.CreateSet<TEntity>();
            var b = a.ToList();

            return  _unitOfWork.CreateSet<TEntity>();
        }
        #endregion
    }
}