using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Kadastro.Aplicacao.DTO;
using Sample.Kadastro.Aplicacao.Extensions;
using Sample.Kadastro.Infraestrutura.Comuns;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Repositories;
using Sample.Kadastro.Dominio.Services;

namespace Sample.Kadastro.Aplicacao
{
    public class UsuarioAppService : IUsuarioAppService
    {
        #region Atributos

        private IUsuarioRepository _usuarioRepository = null;
        private IUsuarioService _usuarioService = null;

        #endregion

        #region Construtor

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        #endregion

        #region IUsuarioAppService membros

        public UsuarioDTO Obter(string login)
        {
            return _usuarioService.ObterPeloLogin(login).ToUsuarioDTO();
        }

        public UsuarioDTO Obter(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDTO> Obter()
        {
            throw new NotImplementedException();
        }

        public List<string> Salvar(UsuarioDTO item)
        {
            throw new NotImplementedException();
        }

        public List<string> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<ItemListaDTO> ObterPerfilDeAcesso()
        {
            return _usuarioService.ObterPerfilDeAcesso().ToItemListaDTO();
        }

        #endregion
    }
}
