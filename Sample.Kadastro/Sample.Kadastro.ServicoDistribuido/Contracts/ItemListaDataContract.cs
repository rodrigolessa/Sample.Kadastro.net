using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text;

namespace Sample.Kadastro.ServicoDistribuido.Contracts
{
    [DataContract]
    public class ItemListaDataContract
    {
        [DataMember]
        public Int64 Id { get; set; }

        [DataMember]
        public String Descricao { get; set; }
    }
}