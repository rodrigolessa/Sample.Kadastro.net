using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.UI.Web.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
            : base()
        {
        }

        public string NomeUsuario { get; set; }
        public List<Ponto> Pontos { get; set; }
    }
}