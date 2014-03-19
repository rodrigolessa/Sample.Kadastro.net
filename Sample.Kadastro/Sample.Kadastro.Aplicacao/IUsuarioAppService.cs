using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Infraestrutura.Comuns;
using Sample.Kadastro.Aplicacao.DTO;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Aplicacao
{
    public interface IUsuarioAppService
    {
        BusinessResponse<Boolean> Autenticar(string login, string senha);
        UsuarioDTO Obter(string login);
        UsuarioDTO Obter(int id);
        List<UsuarioDTO> Obter();
        BusinessResponse<Boolean> Salvar(UsuarioDTO item);
        BusinessResponse<Boolean> Excluir(int id);

        List<ItemListaDTO> ObterPerfilDeAcesso();
    }
}