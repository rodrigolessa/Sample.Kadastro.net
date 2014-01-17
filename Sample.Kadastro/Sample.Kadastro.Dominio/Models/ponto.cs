using System;
using System.Collections.Generic;

namespace Sample.Kadastro.Dominio.Models
{
    public partial class ponto
    {
        public ponto()
        {
            this.intervaloes = new List<intervalo>();
        }

        public int id { get; set; }
        public int idUsuario { get; set; }
        public System.DateTime dia { get; set; }
        public Nullable<System.TimeSpan> horas { get; set; }
        public virtual ICollection<intervalo> intervaloes { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
