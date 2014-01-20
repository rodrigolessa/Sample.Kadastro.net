using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Kadastro.Aplicacao.DTO;
using Sample.Kadastro.Infraestrutura.Comuns;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Repositories;
using Sample.Kadastro.Dominio.Services;

namespace Sample.Kadastro.Aplicacao
{
    public class UsuarioAppService : IUsuarioAppService
    {
        #region Atributos

        private IUsuarioRepository _iusuarioRepository = null;

        #endregion

        #region Construtor

        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {
            _iusuarioRepository = usuarioRepository;
        }

        #endregion

        #region IUsuarioAppService membros

        public UsuarioDTO ObterUsuario(string loginActiveDirectory)
        {
            Usuario usuario = _iusuarioRepository.ObterPeloLogin(loginActiveDirectory).FirstOrDefault();

            return new UsuarioDTO()
            {
                Id = usuario.Id,
                Login = usuario.Login,
                Senha = usuario.Senha,
                Email = usuario.Email,
                EhPrimeiroAcesso = true
            };
        }

        public Usuario ObterUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObterUsuario()
        {
            throw new NotImplementedException();
        }

        public List<string> SalvarUsuario(Usuario item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
