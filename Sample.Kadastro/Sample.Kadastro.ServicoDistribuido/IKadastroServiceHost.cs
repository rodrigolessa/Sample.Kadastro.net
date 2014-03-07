using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Sample.Kadastro.ServicoDistribuido.Contracts;

namespace Sample.Kadastro.ServicoDistribuido
{
    [ServiceContract]
    public interface IKadastroServiceHost
    {
        #region Operações de Usuário

        [OperationContract]
        UsuarioDataContract ObterUsuario(int value);

        [OperationContract]
        UsuarioDataContract ObterUsuarioPeloLogin(string value);

        [OperationContract]
        List<UsuarioDataContract> ListarUsuarios();

        [OperationContract]
        void SalvarUsuario(UsuarioDataContract item);

        [OperationContract]
        void ExcluirUsuario(int value);

        #endregion

        #region Operações de Ponto e Intervalos

        #endregion

        #region Outras Operações

        [OperationContract]
        List<ItemListaDataContract> ListarPerfisDeAcesso();

        #endregion
    }
}
