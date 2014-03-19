using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Infraestrutura.Comuns;
using Sample.Kadastro.Infraestrutura.Comuns.Validator;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Repositories;
using Sample.Kadastro.Dominio.Entities.Enum;
using Sample.Kadastro.Dominio.Extensions;
using Sample.Kadastro.Dominio.Model;

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

        public BusinessResponse<bool> Autenticar(string login, string senha)
        {
            return new BusinessResponse<bool>(false, Messages.ValidationUsuarioLoginBloqueado);
        }

        public Usuario ObterPeloLogin(string login)
        {
            return _usuarioRepository.ObterPeloLogin(login).FirstOrDefault();
        }

        public Usuario Obter(int id)
        {
            return _usuarioRepository.Get(id);
        }

        public List<Usuario> Obter()
        {
            return _usuarioRepository.GetAll().ToList();
        }

        public List<ItemListaModel> ObterPerfilDeAcesso()
        {
            return typeof(PerfilAcesso).ToItemListaModel();
        }

        public BusinessResponse<bool> Salvar(Usuario item)
        {
            bool cadastrado = false;
            string msgErro = string.Empty;

            var erros = item.FazerSeForValido<Usuario>(() =>
            {
                _usuarioRepository.Add(item);
                cadastrado = (_usuarioRepository.UnitOfWork.Commit() > 0);
            });

            if (erros.ExistemErros())
                msgErro = erros.FirstOrDefault();

            return new BusinessResponse<bool>(cadastrado, msgErro);
        }

        public BusinessResponse<bool> Excluir(int id)
        {
            bool excluido = false;
            string msgErro = string.Empty;
            Usuario usuario = _usuarioRepository.Get(id);

            // TODO: Mover para classe de validação
            if (usuario != null)
            {
                _usuarioRepository.Remove(usuario);
                excluido = (_usuarioRepository.UnitOfWork.Commit() > 0);
            }
            else
            {
                msgErro = Messages.ValidationExcluirUsuarioNaoEncontrado;
            }

            return new BusinessResponse<bool>(excluido, msgErro);
        }

        #endregion
    }
}