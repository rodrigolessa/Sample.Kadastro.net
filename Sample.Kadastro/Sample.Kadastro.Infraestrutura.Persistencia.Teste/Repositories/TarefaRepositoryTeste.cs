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
    public class TarefaRepositoryTeste
    {
        private MainUnitOfWork unit;
        private UsuarioRepository usuarioRepository;
        private TarefaRepository tarefaRepository;
        private string loginUsuario = "TesteUsuarioTarefa";

        [SetUp]
        public void Initializer()
        {
            unit = new MainUnitOfWork();
            usuarioRepository = new UsuarioRepository(unit);
            tarefaRepository = new TarefaRepository(unit);
        }

        /// <summary>
        /// Teste positivo de cadastro de tarefas para o usuário
        /// </summary>
        [Test]
        public void CadastrarUmaTarefa()
        {
            #region Scripts para manter a integridade do banco

            var _QUERY_DELETE_INTERVALO = "delete from kadastro.dbo.Intervalo where IdPonto IN (select p.Id from kadastro.dbo.Ponto p where p.IdUsuario IN (select u.Id from kadastro.dbo.Usuario u where u.Login like '" + loginUsuario + "'));";
            unit.ExecuteCommand(_QUERY_DELETE_INTERVALO);

            var _QUERY_DELETE_PONTO = "delete from kadastro.dbo.Ponto where IdUsuario IN (select u.Id from kadastro.dbo.Usuario u where u.Login like '" + loginUsuario + "');";
            unit.ExecuteCommand(_QUERY_DELETE_PONTO);

            var _QUERY_DELETE_TAREFA = "delete from kadastro.dbo.Tarefa where IdUsuario IN (select u.Id from kadastro.dbo.Usuario u where u.Login like '" + loginUsuario + "');";
            unit.ExecuteCommand(_QUERY_DELETE_TAREFA);

            var _QUERY_DELETE_USUARIO = "delete from kadastro.dbo.usuario where Login like '" + loginUsuario + "';";
            unit.ExecuteCommand(_QUERY_DELETE_USUARIO);

            var _QUERY_INSERT_USUARIO = "insert into kadastro.dbo.usuario(Login, Senha, Email, Status) values ('" + loginUsuario + "', '123', 'contato@rodrigolessa.com', 'A');";
            unit.ExecuteCommand(_QUERY_INSERT_USUARIO);

            #endregion

            // Instânciando uma nova tarefa
            var tarefa = new Tarefa();
            tarefa.Descricao = "Lembrar de comprar pão!";
            tarefa.Executada = false;

            // Obter usuário cadastrado
            tarefa.Usuario = usuarioRepository.ObterPeloLogin(loginUsuario).FirstOrDefault();

            // Criando a tarefa
            tarefaRepository.Add(tarefa);
            var linhasAfetadas = unit.Commit();

            Assert.AreEqual(1, linhasAfetadas);
        }

        /// <summary>
        /// Teste positivo para excluir tarefas por usuário
        /// </summary>
        [Test]
        public void ExcluirTarefasPorUsuario()
        {
            this.CadastrarUmaTarefa();

            // Obtem o usuário que possui uma tarefa
            var usuarioCadastrado = usuarioRepository.ObterPeloLogin(loginUsuario).FirstOrDefault();

            Assert.IsNotNull(usuarioCadastrado, "Obtem usuário pelo login!");
            Assert.AreEqual("A", usuarioCadastrado.Status, "Usuário encontrado!");
            Assert.IsNotNull(usuarioCadastrado.Tarefas, "Tarefas cadastradas");
            Assert.GreaterOrEqual(usuarioCadastrado.Tarefas.Count(), 1, "Possui uma tarefa cadastrada");

            // Exclui todas as tarefas do usuário
            foreach (Tarefa tarefa in usuarioCadastrado.Tarefas.ToList())
                tarefaRepository.Remove(tarefa);

            var linhasAfetadas = unit.Commit();

            Assert.GreaterOrEqual(linhasAfetadas, 1, "Tarefas excluidas com sucesso!");
        }
    }
}
