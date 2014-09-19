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
        public TipoMensagemEnum TipoMensagem { get; set; }
        public bool HasError { get; set; }
        public bool HasSuccess { get; set; }

        public ViewModelBase()
        {
            HasError = false;
        }

        internal ViewModelBase(string mensagem, string titulo, TipoMensagemEnum tipoMensagem)
        {
            Mensagem = mensagem;
            Titulo = titulo;
            TipoMensagem = tipoMensagem;
            HasError = true;
        }

        private ViewModelBase(string titulo, TipoMensagemEnum tipoMensagem)
        {
            Titulo = titulo;
            TipoMensagem = tipoMensagem;
            HasError = true;
        }

        public static ViewModelBase Error(string mensagem, string titulo)
        {
            return new ViewModelBase(mensagem, titulo, TipoMensagemEnum.Erros);
        }

        public static ViewModelBase Error(IEnumerable<string> mensagem, string titulo)
        {
            var model = new ViewModelBase(titulo, TipoMensagemEnum.Erros);
            var mensagemArray = mensagem.ToArray();

            var msg = string.Join(Environment.NewLine, mensagemArray);

            model.Mensagem = msg;
            model.HasError = true;
            return model;
        }

        public static ViewModelBase Success(string mensagem, string titulo)
        {
            return new ViewModelBase(mensagem, titulo, TipoMensagemEnum.Success);
        }

        public ViewModelBase DoSuccess(string mensagem, string titulo)
        {
            this.Mensagem = mensagem;
            this.Titulo = titulo;
            this.HasError = false;
            this.HasSuccess = true;
            return this;
        }

        public ViewModelBase DoError(string mensagem, string titulo)
        {
            this.Mensagem = mensagem;
            this.Titulo = titulo;
            this.HasError = true;
            this.HasSuccess = false;
            return this;
        }

        public static ViewModelBase Warning(string mensagem, string titulo)
        {
            return new ViewModelBase(mensagem, titulo, TipoMensagemEnum.Warning);
        }
    }
}