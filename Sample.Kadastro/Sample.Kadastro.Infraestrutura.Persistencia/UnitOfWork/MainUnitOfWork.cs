using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Sample.Kadastro.Dominio;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork.Mapping;

namespace Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork
{
    public class MainUnitOfWork : DbContext, IQueryableUnitOfWork
    {
        #region IDbSet Members

        IDbSet<Usuario> _usuarios;
        public IDbSet<Usuario> Usuarios
        {
            get
            {
                if (_usuarios == null)
                    _usuarios = base.Set<Usuario>();

                return _usuarios;
            }
        }

        IDbSet<Ponto> _pontos;
        public IDbSet<Ponto> Pontos
        {
            get
            {
                if (_pontos == null)
                    _pontos = base.Set<Ponto>();

                return _pontos;
            }
        }

        IDbSet<Intervalo> _intervalos;
        public IDbSet<Intervalo> Intervalos
        {
            get
            {
                if (_intervalos == null)
                    _intervalos = base.Set<Intervalo>();

                return _intervalos;
            }
        }

        IDbSet<Tarefa> _tarefas;
        public IDbSet<Tarefa> Tarefas
        {
            get
            {
                if (_tarefas == null)
                    _tarefas = base.Set<Tarefa>();

                return _tarefas;
            }
        }

        #endregion

        #region IQueryableUnitOfWork Members

        public IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item) where TEntity : class
        {
            base.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            base.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public int Commit()
        {
            return base.SaveChanges();
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

        public void RollbackChanges()
        {
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = System.Data.Entity.EntityState.Unchanged);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion

        #region DbContext Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove unused conventions
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Add entity configurations in a structured way using 'TypeConfiguration’ classes
            modelBuilder.Configurations.Add(new UsuarioTypeConfiguration());
            modelBuilder.Configurations.Add(new PontoTypeConfiguration());
            modelBuilder.Configurations.Add(new IntervaloTypeConfiguration());
            modelBuilder.Configurations.Add(new TarefaTypeConfiguration());
        }

        #endregion
    }
}