using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sample.Kadastro.Aplicacao;
//using Sample.Kadastro.Aplicacao.Extensions;
using Sample.Kadastro.Infraestrutura.Comuns.Validator;
using Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork;
using Sample.Kadastro.Infraestrutura.Persistencia.Repositories;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Entities.Enum;
using Sample.Kadastro.Dominio.Repositories;

namespace Sample.Kadastro.Aplicacao.Teste
{
    [TestFixture]
    public class UsuarioAppServiceTeste
    {
        [SetUp]
        public void Initializer()
        {
        }

        [Test]
        public void SalvarUsuarioSemSenha()
        {
            var unit = new MainUnitOfWork();
            var usuarioRepository = new UsuarioRepository(unit);
            string erroSenha = "erro";

            Usuario usuario = new Usuario();
            usuario.Login = "TesteUsuárioAplicação";
            //usuario.Senha = "123";
            usuario.Status = "A";
            usuario.Email = "contato@rodrigolessa.com";

            var erros = usuario.FazerSeForValido<Usuario>(() =>
                {
                    usuarioRepository.Add(usuario);
                    usuarioRepository.UnitOfWork.Commit();
                    //unit.Commit();
                });

            if (erros.ExistemErros())
                erroSenha = erros.FirstOrDefault();

            Assert.IsTrue(erros.ExistemErros(), "Erros encontrados na validação da entidade!");
            Assert.AreEqual(erroSenha, "O campo Senha da entidade não pode ser nulo...", "Validação do campo senha!");

            //var usuarioCadastrado = usuarioRepository.ObterPeloLogin(usuario.Login).FirstOrDefault();

            //Assert.IsNotNull(usuarioCadastrado);
            //Assert.AreEqual(usuarioCadastrado.Login, usuario.Login, "Usuário cadastrado com sucesso!");
        }
    }
}
