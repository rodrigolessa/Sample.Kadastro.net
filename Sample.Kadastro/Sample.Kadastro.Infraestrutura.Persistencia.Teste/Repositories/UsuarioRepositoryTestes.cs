using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork;
using Sample.Kadastro.Infraestrutura.Persistencia.Repositories;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Entities.Enum;

namespace Sample.Kadastro.Infraestrutura.Persistencia.Teste.Repositories
{
    [TestClass]
    public class UsuarioRepositoryTestes
    {
        [TestMethod]
        public void ObterUsuarioPeloLogin()
        {
            var unit = new MainUnitOfWork();
            var usuarioRepository = new UsuarioRepository(unit);
            
            var usuario = new Usuario();
            usuario.Login = "TesteUsuarioLogin";
            usuario.Senha = "123";
            usuario.PerfilAcesso = PerfilAcesso.Desenvolvedor;

            usuarioRepository.Add(usuario);
            unit.CommitAndRefreshChanges();

            var usuarioCadastrado = usuarioRepository.ObterPeloLogin(usuario.Login).FirstOrDefault();

            Assert.IsNotNull(usuarioCadastrado);
            Assert.IsTrue(usuarioCadastrado.Login == usuario.Login, "Usuário de teste cadastrado com sucesso!");
        }
    }
}
