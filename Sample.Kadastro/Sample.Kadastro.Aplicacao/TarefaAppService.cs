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

        private ITarefaRepository _tarefaRepository = null;
        private ITarefaService _tarefaService = null;

        #endregion

        #region Construtor

        public TarefaAppService(ITarefaRepository tarefaRepository, ITarefaService tarefaService)
        {
            _tarefaRepository = tarefaRepository;
            _tarefaService = tarefaService;
        }

        #endregion

        #region IUsuarioAppService membros

        public List<TarefaDTO> Obter(string login)
        {
            return _tarefaService.Obter(login).ToTarefaDTO();
        }

        public BusinessResponse<bool> Salvar(TarefaDTO item)
        {
            return _tarefaService.Salvar(item.ToUsuario());
        }

        public BusinessResponse<bool> Excluir(int id)
        {
            return _tarefaService.Excluir(id);
        }

        public BusinessResponse<bool> Executar(int id)
        {
            return _tarefaService.Executar(id);
        }

#endregion
    }
}
