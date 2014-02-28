using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Kadastro.ServicoDistribuido.Contracts;
using Sample.Kadastro.Aplicacao.DTO;

namespace Sample.Kadastro.ServicoDistribuido.Extensions
{
    public static class PerfilAcessoExtensions
    {
        public static List<ItemListaDataContract> ToPerfilAcessoDataContract(this List<ItemListaDTO> lista)
        {
            return lista.Select(x => x.ToPerfilAcessoDataContract()).ToList();
        }

        public static ItemListaDataContract ToPerfilAcessoDataContract(this ItemListaDTO item)
        {
            return new ItemListaDataContract()
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}