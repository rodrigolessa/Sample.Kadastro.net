using System;
using System.Collections.Generic;

namespace Sample.Kadastro.Dominio.Entities
{
    public partial class Usuario : EntityBase
    {
        public Usuario()
        {
            this.Pontos = new List<Ponto>();
            this.Tarefas = new List<Tarefa>();
        }

        public int? Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Ponto> Pontos { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
