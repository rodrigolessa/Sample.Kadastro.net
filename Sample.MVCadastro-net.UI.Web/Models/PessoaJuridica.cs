using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sample.MVCadastro_net.UI.Web.Models
{
    public class PessoaJuridica : Pessoa
    {
        [DisplayName("Documento")]
        public virtual string CNPJ { get; set; }
    }
}