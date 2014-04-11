using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text;

namespace Sample.Kadastro.ServicoDistribuido.Contracts
{
    [DataContract]
    public class TarefaDataContract
    {
        [DataMember]
        public Int64 Id { get; set; }
        
        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string Descricao { get; set; }

        [DataMember]
        public bool Executada { get; set; }
    }
}