using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Kadastro.Dominio
{
    public interface IQueryableUnitOfWork : IUnitOfWork, ISql
    {
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        // ObjectStateManager
        void Attach<TEntity>(TEntity item) where TEntity : class;
        void SetModified<TEntity>(TEntity item) where TEntity : class;
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
    }
}
