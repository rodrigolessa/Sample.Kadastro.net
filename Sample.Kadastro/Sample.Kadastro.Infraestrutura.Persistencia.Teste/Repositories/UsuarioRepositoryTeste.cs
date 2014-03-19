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
        private MainUnitOfWork unit;
        private UsuarioRepository usuarioRepository;

        [SetUp]
        public void Initializer()
        {
            unit = new MainUnitOfWork();
            usuarioRepository = new UsuarioRepository(unit);
        }

        /// <summary>
        /// Teste positivo de cadastro de usuário
        /// </summary>
        [Test]
        public void ObterUsuarioPeloLogin()
        {
            var _QUERY_DELETE_USUARIO = "delete from kadastro.dbo.usuario where Login like 'TesteExcluirUsuario';";
            unit.ExecuteCommand(_QUERY_DELETE_USUARIO);

            var usuario = new Usuario();
            usuario.Login = "TesteUsuarioLogin";
            usuario.Senha = "123";
            usuario.Status = "A";
            usuario.Email = "contato@rodrigolessa.com";
            //usuario.PerfilAcesso = PerfilAcesso.Desenvolvedor;

            usuarioRepository.Add(usuario);
            unit.Commit();

            var usuarioCadastrado = usuarioRepository.ObterPeloLogin(usuario.Login).FirstOrDefault();

            Assert.IsNotNull(usuarioCadastrado);
            Assert.AreEqual(usuarioCadastrado.Login, usuario.Login, "Usuário cadastrado com sucesso!");
            Assert.AreEqual("Ativo", usuarioCadastrado.DescricaoDoStatus);
        }

        /// <summary>
        /// Teste positivo para excluir um usuário
        /// </summary>
        [Test]
        public void ExcluirUsuarioPeloLogin()
        {
            var _QUERY_INSERT_USUARIO = "insert into kadastro.dbo.usuario(Login, Senha, Email, Status) values ('TesteExcluirUsuario', '123', 'contato@rodrigolessa.com', 'A');";
            unit.ExecuteCommand(_QUERY_INSERT_USUARIO);

            var loginUsuario = "TesteExcluirUsuario";
            var usuarioCadastrado = usuarioRepository.ObterPeloLogin(loginUsuario).FirstOrDefault();

            Assert.IsNotNull(usuarioCadastrado, "Obtem usuário pelo login!");
            Assert.IsTrue(usuarioCadastrado.Login == loginUsuario, "Usuário encontrado!");

            usuarioRepository.Remove(usuarioCadastrado);
            unit.Commit();

            var usuarioExcluido = usuarioRepository.ObterPeloLogin(loginUsuario).FirstOrDefault();

            Assert.IsNull(usuarioExcluido, "Usuário excluido com sucesso!");
        }
    }
}
