using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Sample.Kadastro.ServicoDistribuido.Contracts;
using Sample.Kadastro.Aplicacao;

namespace Sample.Kadastro.ServicoDistribuido
{
    public class UsuarioServiceHost : IUsuarioServiceHost
    {
        public UsuarioDataContract ObterUsuario(int value)
        {
            throw new NotImplementedException();
        }

        public UsuarioDataContract ObterUsuarioPeloLogin(string value)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDataContract> ListarUsuarios()
        {
            throw new NotImplementedException();
        }

        public void SalvarUsuario(UsuarioDataContract item)
        {
            throw new NotImplementedException();
        }
    }
}
