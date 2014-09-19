using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Kadastro.Aplicacao.DTO
{
    public class PontoDTO
    {
        public PontoDTO()
        {
            this.Intervalos = new List<IntervaloDTO>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public System.DateTime Dia { get; set; }
        public Nullable<System.TimeSpan> Horas { get; set; }
        public virtual ICollection<IntervaloDTO> Intervalos { get; set; }
    }
}
