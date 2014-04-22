using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Kadastro.Aplicacao.DTO;
using Sample.Kadastro.Aplicacao.Extensions;
using Sample.Kadastro.Infraestrutura.Comuns;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Repositories;
using Sample.Kadastro.Dominio.Services;

namespace Sample.Kadastro.Aplicacao
{
    public class TarefaAppService : ITarefaAppService
    {
        #region Atributos

        private ITarefaRepository _usuarioRepository = null;
        private ITarefaService _usuarioService = null;

        #endregion

        #region Construtor

        public TarefaAppService(ITarefaRepository usuarioRepository, ITarefaService usuarioService)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        #endregion

        #region IUsuarioAppService membros

        public List<TarefaDTO> Obter(string login)
        {
            throw new NotImplementedException();
        }

        public BusinessResponse<bool> Salvar(TarefaDTO item)
        {
            throw new NotImplementedException();
        }

        public BusinessResponse<bool> Excluir(long id)
        {
            throw new NotImplementedException();
        }

        public BusinessResponse<bool> Executar(long id)
        {
            throw new NotImplementedException();
        }

#endregion
    }
}
