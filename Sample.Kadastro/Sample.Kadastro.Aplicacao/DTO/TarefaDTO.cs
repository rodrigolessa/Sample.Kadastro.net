using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Kadastro.Aplicacao.DTO
{
    public class TarefaDTO
    {
        public Nullable<Int32> Id { get; set; }
        public int IdUsuario { get; set; }
        public string Descricao { get; set; }
        public bool Executada { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
