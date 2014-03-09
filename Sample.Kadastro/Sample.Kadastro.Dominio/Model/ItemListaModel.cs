using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Kadastro.Dominio.Model
{
    public class ItemListaModel
    {
        public ItemListaModel() { }
        public ItemListaModel(Int64 id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        public Int64 Id { get; set; }
        public string Descricao { get; set; }
    }
}
