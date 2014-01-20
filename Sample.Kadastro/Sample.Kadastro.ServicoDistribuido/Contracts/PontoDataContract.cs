using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text;

namespace Sample.Kadastro.ServicoDistribuido.Contracts
{
    [DataContract]
    public class PontoDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime Dia { get; set; }

        [DataMember]
        public TimeSpan Horas { get; set; }

        [DataMember]
        public List<IntervaloDataContract> Intervalos { get; set; }
    }
}