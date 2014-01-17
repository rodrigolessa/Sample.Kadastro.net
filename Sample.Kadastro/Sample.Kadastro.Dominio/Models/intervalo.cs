using System;
using System.Collections.Generic;

namespace Sample.Kadastro.Dominio.Models
{
    public partial class intervalo
    {
        public long id { get; set; }
        public int idPonto { get; set; }
        public Nullable<System.TimeSpan> entrada { get; set; }
        public Nullable<System.TimeSpan> saida { get; set; }
        public virtual ponto ponto { get; set; }
    }
}
