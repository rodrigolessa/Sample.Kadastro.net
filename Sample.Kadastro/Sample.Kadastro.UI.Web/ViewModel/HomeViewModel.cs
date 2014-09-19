using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Kadastro.Aplicacao;
using Sample.Kadastro.Aplicacao.DTO;

namespace Sample.Kadastro.UI.Web.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
            : base()
        {
        }

        public UsuarioDTO UsuarioLogado { get; set; }
        public List<PontoDTO> Pontos { get; set; }
    }
}