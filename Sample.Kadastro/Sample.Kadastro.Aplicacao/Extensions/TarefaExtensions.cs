using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Aplicacao.DTO;

namespace Sample.Kadastro.Aplicacao.Extensions
{
    public static class TarefaExtensions
    {
        public static List<TarefaDTO> ToTarefaDTO(this List<Tarefa> lista)
        {
            return lista.Select(x => x.ToTarefaDTO()).ToList();
        }

        public static TarefaDTO ToTarefaDTO(this Tarefa item)
        {
            return new TarefaDTO()
            {
                Id = item.Id,
                IdUsuario = item.IdUsuario,
                Descricao = item.Descricao,
                Executada = item.Executada.HasValue ? item.Executada.Value : false
            };
        }

        public static Tarefa ToUsuario(this TarefaDTO item)
        {
            return new Tarefa()
            {
                Id = item.Id,
                IdUsuario = item.IdUsuario,
                Descricao = item.Descricao,
                Executada = item.Executada
            };
        }
    }
}
