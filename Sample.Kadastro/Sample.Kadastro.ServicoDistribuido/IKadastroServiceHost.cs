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
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ObterUsuario/{id}")]
        UsuarioDataContract ObterUsuario(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ObterUsuarioPeloLogin/{login}")]
        UsuarioDataContract ObterUsuarioPeloLogin(string login);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ListarUsuarios/")]
        List<UsuarioDataContract> ListarUsuarios();

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SalvarUsuario/item")]
        void SalvarUsuario(string item);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ExcluirUsuario/{id}")]
        void ExcluirUsuario(string id);

        #endregion

        #region Operações de Ponto e Intervalos

        #endregion

        #region Outras Operações

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ListarPerfisDeAcesso/")]
        List<ItemListaDataContract> ListarPerfisDeAcesso();

        #endregion
    }
}
