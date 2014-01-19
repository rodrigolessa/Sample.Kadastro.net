using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Dominio;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Repositories;
using Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork;

namespace Sample.Kadastro.Infraestrutura.Persistencia.Repositories
{
    public partial class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        #region Construtor

        /// <summary>
        /// Cria uma Nova Instância
        /// </summary>
        /// <param name="unitOfWork">Associado ao Unit Of Work</param>
        public UsuarioRepository(MainUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        public IEnumerable<Usuario> ObterPeloLogin(string login)
        {
            return this.GetFiltered(x => x.Login == login);
        }
    }
}
