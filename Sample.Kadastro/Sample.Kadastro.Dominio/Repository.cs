using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Dominio
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        #region Members

        IQueryableUnitOfWork _UnitOfWork;

        #endregion

        #region Construtor

        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");

            _UnitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository Members

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
        }

        public virtual void Add(TEntity item)
        {
            if (item != (TEntity)null)
                GetSet().Add(item);
            //TODO: Gravar loggerFactory
        }

        public virtual void Remove(TEntity item)
        {
            if (item != (TEntity)null)
            {
                _UnitOfWork.Attach(item);

                GetSet().Remove(item);
            }
            //TODO: Gravar loggerFactory
        }

        public virtual void Modify(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.SetModified(item);
            //TODO: Gravar loggerFactory
        }

        public virtual void TrackItem(TEntity item)
        {
            if (item != (TEntity)null)
                _UnitOfWork.Attach<TEntity>(item);
            //TODO: Gravar loggerFactory
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual TEntity Get(int id)
        {
            if (id != 0)
                return GetSet().Find(id);
            else
                return null;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet();
        }

        public virtual IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_UnitOfWork != null)
                _UnitOfWork.Dispose();
        }

        #endregion

        #region Métodos Privados

        IDbSet<TEntity> dbset = null;
        IDbSet<TEntity> GetSet()
        {
            if (dbset == null)
                dbset = _UnitOfWork.CreateSet<TEntity>();

            return dbset;
        }
        #endregion
    }
}
