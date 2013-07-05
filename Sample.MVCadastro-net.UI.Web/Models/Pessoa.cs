using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sample.MVCadastro_net.UI.Web.Models
{
    public class Pessoa
    {
        [DisplayName("Código")]
        public virtual Guid PessoaId { get; set; }
        [DisplayName("Nome")]
        [StringLength(100)]
        public virtual string Nome { get; set; }
        [DisplayName("Situação")]
        [StringLength(1)]
        public virtual string Status { get; set; }
    }
}