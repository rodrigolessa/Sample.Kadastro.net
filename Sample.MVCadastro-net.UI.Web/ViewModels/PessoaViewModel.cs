using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.MVCadastro_net.UI.Web.Models;
using Sample.MVCadastro_net.UI.Web.Enum;

namespace Sample.MVCadastro_net.UI.Web.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            Pessoa = new Pessoa();
            ListaPessoaFisica = new List<PessoaFisica>();
            ListaPessoaJuridica = new List<PessoaJuridica>();
            _listaTipoPessoa = from TipoPessoaEnum s in System.Enum.GetValues(typeof(TipoPessoaEnum)) select new { ID = s, Name = s.ToString() };
        }

        private dynamic _listaTipoPessoa;

        public Pessoa Pessoa { get; set; }
        public List<PessoaFisica> ListaPessoaFisica { get; set; }
        public List<PessoaJuridica> ListaPessoaJuridica { get; set; }
        public dynamic ListaTipoPessoa 
        {
            get
            {
                return _listaTipoPessoa;
            }
        }
    }
}