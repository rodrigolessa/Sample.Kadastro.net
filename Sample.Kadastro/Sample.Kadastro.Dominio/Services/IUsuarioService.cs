using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Entities.Enum;

namespace Sample.Kadastro.Dominio.Services
{
    public interface IUsuarioService
    {
        bool Autenticar();
        Usuario ObterPeloLogin(string login);
        List<PerfilAcesso> ObterPerfilDeAcesso();
    }
}
