using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Dominio
{
    // Referências:
    // http://martinfowler.com/eaaCatalog/repository.html
    // http://blogs.msdn.com/adonet/archive/2009/06/16/using-repository-and-unit-of-work-patterns-with-entity-framework-4-0.aspx
    public interface IRepository<TEntity> : IDisposable
        where TEntity : EntityBase
    {
        IUnitOfWork UnitOfWork { get; }

        void Add(TEntity item);
        void Remove(TEntity item);
        void Modify(TEntity item);
        void TrackItem(TEntity item);
        void Merge(TEntity persisted, TEntity current);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);
    }
}
