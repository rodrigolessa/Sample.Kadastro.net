using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork;
using Sample.Kadastro.Infraestrutura.Persistencia.Repositories;
using Sample.Kadastro.Dominio;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Entities.Enum;
using Sample.Kadastro.Dominio.Repositories;
using Sample.Kadastro.Dominio.Services;

namespace Sample.Kadastro.Dominio.Teste.Services
{
    [TestFixture]
    public class TarefaServiceTeste
    {
        private MainUnitOfWork _unit;
        private UsuarioRepository _usuarioRepository;
        private UsuarioService _usuarioService;
        private TarefaRepository _tarefaRepository;
        private TarefaService _tarefaService;
        private string _loginUsuario = "TesteUsuarioTarefa";

        [SetUp]
        public void Initializer()
        {
            _unit = new MainUnitOfWork();
            _usuarioRepository = new UsuarioRepository(_unit);
            _usuarioService = new UsuarioService(_usuarioRepository);
            _tarefaRepository = new TarefaRepository(_unit);
            _tarefaService = new TarefaService(_tarefaRepository);
        }

        [Test]
        public void InserirTarefaPorUsuario()
        {
            // Obter Usuário para relacionar a tarefa
            var usuario = _usuarioService.ObterPeloLogin(_loginUsuario);
            Assert.IsNotNull(usuario, "Usuário Cadastrado");

            // Instânciando uma nova tarefa
            var tarefa = new Tarefa();
            tarefa.Descricao = "Comprar leite!";
            tarefa.Executada = false;
            tarefa.Usuario = usuario;

            var retorno = _tarefaService.Salvar(tarefa);

            Assert.IsTrue(retorno.Response);
        }

        [Test]
        public void InserirTarefaExecutadaPorIdUsuario()
        {
            // Obter Usuário para relacionar a tarefa
            var usuario = _usuarioService.ObterPeloLogin(_loginUsuario);
            Assert.IsNotNull(usuario, "Usuário Cadastrado");
            Assert.AreEqual("contato@rodrigolessa.com", usuario.Email);

            // Instânciando uma nova tarefa
            var tarefa = new Tarefa();
            tarefa.IdUsuario = usuario.Id.Value;
            tarefa.Descricao = "Comprar 100 gramas de presunto.";
            tarefa.Executada = true;

            var retorno = _tarefaService.Salvar(tarefa);
            Assert.IsTrue(retorno.Response);
        }

        [Test]
        public void ExecutarTarefaPorLoginUsuario()
        {
            // Instânciando uma nova tarefa não executada
            var tarefa = new Tarefa();
            tarefa.Descricao = "Comprar 200 gramas de queijo cottage.";
            tarefa.Executada = false;
            tarefa.Usuario = _usuarioService.ObterPeloLogin(_loginUsuario);

            // Grava a tarefa para o usuário
            _tarefaService.Salvar(tarefa);

            // Obter tarefas do usuário
            var tarefasDoUsuario = _tarefaService.Obter(_loginUsuario);
            Assert.IsNotNull(tarefasDoUsuario);
            Assert.GreaterOrEqual(tarefasDoUsuario.Count, 1);

            var tarefaParaExecutar = tarefasDoUsuario.Where(x => x.Executada == false && x.Descricao.Contains("queijo")).FirstOrDefault();
            Assert.IsNotNull(tarefaParaExecutar);

            var executada = _tarefaService.Executar(tarefaParaExecutar.Id.Value);
            Assert.IsTrue(executada.Response);
        }

        [Test]
        public void ExcluirTarefaDoUsuario()
        {
            // Instânciando uma nova tarefa não executada
            var tarefa = new Tarefa();
            tarefa.Descricao = "100 gramas de queijo Gorgonzola.";
            tarefa.Executada = false;
            tarefa.Usuario = _usuarioService.ObterPeloLogin(_loginUsuario);
            // Grava a tarefa para o usuário
            _tarefaService.Salvar(tarefa);

            // Obter tarefas do usuário
            var tarefaParaExcluir = _tarefaService.Obter(_loginUsuario).Where(x => x.Descricao.Contains("queijo")).FirstOrDefault();
            Assert.IsNotNull(tarefaParaExcluir);

            var excluida = _tarefaService.Excluir(tarefaParaExcluir.Id.Value);
            Assert.IsTrue(excluida.Response);
        }
    }
}
