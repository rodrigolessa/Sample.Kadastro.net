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
    }
}
