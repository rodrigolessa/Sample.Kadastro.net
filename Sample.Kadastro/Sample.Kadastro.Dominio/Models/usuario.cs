using System;
using System.Collections.Generic;

namespace Sample.Kadastro.Dominio.Models
{
    public partial class usuario
    {
        public usuario()
        {
            this.pontoes = new List<ponto>();
        }

        public int id { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public virtual ICollection<ponto> pontoes { get; set; }
    }
}
