using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Kadastro.Aplicacao.DTO;
using Sample.Kadastro.ServicoDistribuido.Contracts;

namespace Sample.Kadastro.ServicoDistribuido.Extensions
{
    public static class UsuarioDTOExtensions
    {
        public static List<UsuarioDataContract> ToUsuarioDataContract(this List<UsuarioDTO> lista)
        {
            return lista.Select(x => x.ToUsuarioDataContract()).ToList();
        }

        public static UsuarioDataContract ToUsuarioDataContract(this UsuarioDTO item)
        {
            return new UsuarioDataContract()
            {
                Id = item.Id,
                Login = item.Login,
                Senha = item.Senha,
                Email = item.Email,
                Status = item.Status,
                DescricaoDoStatus = item.DescricaoDoStatus
            };
        }

        public static UsuarioDTO ToUsuarioDTO(this UsuarioDataContract item)
        {
            return new UsuarioDTO()
            {
                Id = item.Id,
                Login = item.Login,
                Senha = item.Senha,
                Email = item.Email,
                Status = item.Status,
                DescricaoDoStatus = item.DescricaoDoStatus
            };
        }
    }
}