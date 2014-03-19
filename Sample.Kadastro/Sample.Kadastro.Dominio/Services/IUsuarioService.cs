using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Infraestrutura.Comuns;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Entities.Enum;
using Sample.Kadastro.Dominio.Model;

namespace Sample.Kadastro.Dominio.Services
{
    public interface IUsuarioService
    {
        BusinessResponse<Boolean> Autenticar(string login, string senha);
        Usuario ObterPeloLogin(string login);
        Usuario Obter(int id);
        List<Usuario> Obter();
        List<ItemListaModel> ObterPerfilDeAcesso();
        BusinessResponse<Boolean> Salvar(Usuario item);
        BusinessResponse<Boolean> Excluir(int id);
    }
}
