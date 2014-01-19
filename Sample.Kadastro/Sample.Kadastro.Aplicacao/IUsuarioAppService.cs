using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Aplicacao.DTO;

namespace Sample.Kadastro.Aplicacao
{
    public interface IUsuarioAppService
    {
        UsuarioDTO ObterUsuario(string loginActiveDirectory);
        List<string> SalvarUsuario(UsuarioDTO item);
    }
}
