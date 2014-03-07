using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Sample.Kadastro.Infraestrutura.Persistencia.Repositories;
using Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork;
using Sample.Kadastro.Dominio.Services;
using Sample.Kadastro.Aplicacao;
using Sample.Kadastro.ServicoDistribuido.Contracts;
using Sample.Kadastro.ServicoDistribuido.Extensions;

namespace Sample.Kadastro.ServicoDistribuido
{
    public class KadastroServiceHost : IKadastroServiceHost
    {
        #region Atributos

        private readonly IUsuarioAppService _usuarioAppService;

        #endregion

        #region Construtor

        public KadastroServiceHost()
        {
            //context
            var unit = new MainUnitOfWork();

            //repositories
            var usuarioRepository = new UsuarioRepository(unit);
            var pontoRepository = new PontoRepository(unit);
            var intervaloRepository = new IntervaloRepository(unit);

            //services
            var usuarioService = new UsuarioService(usuarioRepository);
            //var pontoRepository = new PontoService(pontoRepository, intervaloRepository);

            //applications
            _usuarioAppService = new UsuarioAppService(usuarioRepository, usuarioService);
        }

        #endregion

        #region Operações de Usuário

        public UsuarioDataContract ObterUsuario(int value)
        {
            throw new NotImplementedException();
        }

        public UsuarioDataContract ObterUsuarioPeloLogin(string value)
        {
            return _usuarioAppService.Obter(value).ToUsuarioDataContract();
        }

        public List<UsuarioDataContract> ListarUsuarios()
        {
            throw new NotImplementedException();
        }

        public void SalvarUsuario(UsuarioDataContract item)
        {
            throw new NotImplementedException();
        }

        public void ExcluirUsuario(int value)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Operações de Ponto e Intervalos

        #endregion

        #region Outras Operações

        public List<ItemListaDataContract> ListarPerfisDeAcesso()
        {
            return _usuarioAppService.ObterPerfilDeAcesso().ToPerfilAcessoDataContract();
        }

        #endregion
    }
}
