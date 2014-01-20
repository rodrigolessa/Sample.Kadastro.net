using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text;

namespace Sample.Kadastro.ServicoDistribuido.Contracts
{
    [DataContract]
    public class IntervaloDataContract
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public TimeSpan Entrada { get; set; }

        [DataMember]
        public TimeSpan Saida { get; set; }
    }
}