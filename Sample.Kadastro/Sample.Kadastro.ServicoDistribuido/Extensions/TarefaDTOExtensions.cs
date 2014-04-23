using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Kadastro.Aplicacao.DTO;
using Sample.Kadastro.ServicoDistribuido.Contracts;

namespace Sample.Kadastro.ServicoDistribuido.Extensions
{
    public static class TarefaDTOExtensions
    {
        public static List<TarefaDataContract> ToTarefaDataContract(this List<TarefaDTO> lista)
        {
            return lista.Select(x => x.ToTarefaDataContract()).ToList();
        }

        public static TarefaDataContract ToTarefaDataContract(this TarefaDTO item)
        {
            return new TarefaDataContract()
            {
                Id = item.Id,
                IdUsuario = item.IdUsuario,
                Descricao = item.Descricao,
                Executada = item.Executada
            };
        }

        public static TarefaDTO ToTarefaDTO(this TarefaDataContract item)
        {
            return new TarefaDTO()
            {
                Id = item.Id,
                IdUsuario = item.IdUsuario,
                Descricao = item.Descricao,
                Executada = item.Executada
            };
        }
    }
}