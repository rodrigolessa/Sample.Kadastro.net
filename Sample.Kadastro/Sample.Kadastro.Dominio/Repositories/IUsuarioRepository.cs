using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Dominio.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> ObterPeloLogin(string login);
    }
}