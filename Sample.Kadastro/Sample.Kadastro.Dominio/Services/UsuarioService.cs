using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Repositories;
using Sample.Kadastro.Dominio.Entities.Enum;

namespace Sample.Kadastro.Dominio.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region Atributos

        private readonly IUsuarioRepository _usuarioRepository;

        #endregion

        #region Construtor

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        #endregion

        #region IUsuarioService membros

        public bool Autenticar()
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPeloLogin(string login)
        {
            return _usuarioRepository.ObterPeloLogin(login).FirstOrDefault();
        }

        public List<PerfilAcesso> ObterPerfilDeAcesso()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}