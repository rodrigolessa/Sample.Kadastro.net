using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Dominio.Entities.Enum;
using Sample.Kadastro.Dominio.Model;
using Sample.Kadastro.Aplicacao.DTO;

namespace Sample.Kadastro.Aplicacao.Extensions
{
    public static class ItemListaExtensions
    {
        public static List<ItemListaDTO> ToItemListaDTO(this List<ItemListaModel> lista)
        {
            return lista.Select(x => x.ToItemListaDTO()).ToList();
        }

        public static ItemListaDTO ToItemListaDTO(this ItemListaModel item)
        {
            return new ItemListaDTO()
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}
