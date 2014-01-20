using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Aplicacao.DTO;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Aplicacao
{
    public interface IUsuarioAppService
    {
        UsuarioDTO ObterUsuario(string loginActiveDirectory);
        Usuario ObterUsuario(int id);
        List<Usuario> ObterUsuario();
        List<string> SalvarUsuario(Usuario item);
    }
}