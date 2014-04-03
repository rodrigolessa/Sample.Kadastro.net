using System;
using System.Collections.Generic;

namespace Sample.Kadastro.Dominio.Entities
{
    public partial class Tarefa : EntityBase
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Descricao { get; set; }
        public Nullable<Boolean> Executada { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
