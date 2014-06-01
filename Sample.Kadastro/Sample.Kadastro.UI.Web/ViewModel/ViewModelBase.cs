using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Kadastro.UI.Web.ViewModel
{
    public class ViewModelBase
    {
        public string Mensagem { get; set; }
        public string Titulo { get; set; }
        //public TipoMensagem TipoMensagem { get; set; }
        public bool HasError { get; set; }
        public bool HasSuccess { get; set; }

        public ViewModelBase()
        {
            HasError = false;
        }
    }
}