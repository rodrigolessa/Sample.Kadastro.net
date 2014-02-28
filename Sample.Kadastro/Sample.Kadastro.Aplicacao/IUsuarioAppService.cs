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
        UsuarioDTO Obter(string login);
        UsuarioDTO Obter(int id);
        List<UsuarioDTO> Obter();
        List<string> Salvar(UsuarioDTO item);
        List<string> Excluir(int id);

        List<ItemListaDTO> ObterPerfilDeAcesso();
    }
}