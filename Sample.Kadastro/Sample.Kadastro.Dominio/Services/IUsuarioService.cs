using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Entities.Enum;
using Sample.Kadastro.Dominio.Model;

namespace Sample.Kadastro.Dominio.Services
{
    public interface IUsuarioService
    {
        bool Autenticar();
        Usuario ObterPeloLogin(string login);
        Usuario Obter(int id);
        List<Usuario> Obter();
        List<string> Salvar(Usuario item);
        List<string> Excluir(int id);
        List<ItemListaModel> ObterPerfilDeAcesso();
    }
}
