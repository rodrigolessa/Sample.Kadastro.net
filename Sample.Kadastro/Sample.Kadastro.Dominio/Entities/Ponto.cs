using System;
using System.Collections.Generic;

namespace Sample.Kadastro.Dominio.Entities
{
    public partial class Ponto : EntityBase
    {
        public Ponto()
        {
            this.Intervalos = new List<Intervalo>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public System.DateTime Dia { get; set; }
        public Nullable<System.TimeSpan> Horas { get; set; }
        public virtual ICollection<Intervalo> Intervalos { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
