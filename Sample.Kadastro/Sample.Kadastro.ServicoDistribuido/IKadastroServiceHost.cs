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
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SalvarUsuario/")]
        BusinessResponse<Boolean> SalvarUsuario(UsuarioDataContract usuario);
        //BusinessResponse<Boolean> SalvarUsuario(Nullable<Int32> id, string login, string senha, string email, string status);
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SalvarUsuario/{id}/{login}/{senha}/{email}/{status}")]

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ExcluirUsuario/")]
        BusinessResponse<Boolean> ExcluirUsuario(int id);

        #endregion

        #region Operações de Ponto e Intervalos

        #endregion

        #region Outras Operações

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ListarPerfisDeAcesso/")]
        List<ItemListaDataContract> ListarPerfisDeAcesso();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ListarTarefas/")]
        List<TarefaDataContract> ListarTarefas(int idUsuario);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SalvarTarefa/")]
        BusinessResponse<Boolean> SalvarTarefa(TarefaDataContract tarefa);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ExcluirTarefa/")]
        BusinessResponse<Boolean> ExcluirTarefa(Int64 id);

        #endregion
    }
}