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
    public interface IUsuarioServiceHost
    {
        [OperationContract]
        UsuarioDataContract ObterUsuario(int value);

        [OperationContract]
        UsuarioDataContract ObterUsuarioPeloLogin(string value);

        [OperationContract]
        List<UsuarioDataContract> ListarUsuarios();

        [OperationContract]
        void SalvarUsuario(UsuarioDataContract item);
    }
}
