using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Sample.Kadastro.Infraestrutura.Comuns;
using Sample.Kadastro.ServicoDistribuido.Contracts;

namespace Sample.Kadastro.ServicoDistribuido
{
    [ServiceContract]
    public interface IKadastroServiceHost
    {
        #region Operações de Usuário

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Autenticar/{login}/{senha}")]
        BusinessResponse<Boolean> Autenticar(string login, string senha);

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
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SalvarUsuario/{id}/{login}/{senha}/{email}/{status}")]
        BusinessResponse<Boolean> SalvarUsuario(string id, string login, string senha, string email, string status);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ExcluirUsuario/{id}")]
        BusinessResponse<Boolean> ExcluirUsuario(string id);

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