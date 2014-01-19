using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork;
using Sample.Kadastro.Infraestrutura.Persistencia.Repositories;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Entities.Enum;
using Sample.Kadastro.Dominio.Repositories;

namespace Sample.Kadastro.Infraestrutura.Persistencia.Teste.Repositories
{
    [TestFixture]
    public class UsuarioRepositoryTeste
    {
        private string loginUsuario = "TesteUsuarioLogin";

        [SetUp]
        public void Initializer()
        {
        }

        /// <summary>
        /// Teste positivo de cadastro de usuário
        /// </summary>
        [Test]
        public void ObterUsuarioPeloLogin()
        {
            var unit = new MainUnitOfWork();
            var usuarioRepository = new UsuarioRepository(unit);

            var usuario = new Usuario();
            usuario.Login = loginUsuario;
            usuario.Senha = "123";
            usuario.Status = "A";
            usuario.Email = "contato@rodrigolessa.com";
            //usuario.PerfilAcesso = PerfilAcesso.Desenvolvedor;

            usuarioRepository.Add(usuario);
            unit.Commit();

            var usuarioCadastrado = usuarioRepository.ObterPeloLogin(usuario.Login).FirstOrDefault();

            Assert.IsNotNull(usuarioCadastrado);
            Assert.AreEqual(usuarioCadastrado.Login, usuario.Login, "Usuário cadastrado com sucesso!");
        }

        /// <summary>
        /// Teste positivo para excluir um usuário
        /// </summary>
        [Test]
        public void ExcluirUsuarioPeloLogin()
        {
            var unit = new MainUnitOfWork();
            var usuarioRepository = new UsuarioRepository(unit);
            var usuarioCadastrado = usuarioRepository.ObterPeloLogin(loginUsuario).FirstOrDefault();

            Assert.IsTrue(usuarioCadastrado.Login == loginUsuario, "Usuário encontrado!");

            usuarioRepository.Remove(usuarioCadastrado);
            unit.Commit();

            var usuarioExcluido = usuarioRepository.ObterPeloLogin(loginUsuario).FirstOrDefault();

            Assert.IsNull(usuarioExcluido, "Usuário excluido com sucesso!");
        }
    }
}
