using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Infraestrutura.Comuns;
using Sample.Kadastro.Infraestrutura.Comuns.Validator;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Repositories;
using Sample.Kadastro.Dominio.Entities.Enum;
using Sample.Kadastro.Dominio.Extensions;
using Sample.Kadastro.Dominio.Model;

namespace Sample.Kadastro.Dominio.Services
{
    public class TarefaService : ITarefaService
    {
        #region Atributos

        private readonly ITarefaRepository _tarefaRepository;

        #endregion

        #region Construtor

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        #endregion

        #region IUsuarioService membros

        public List<Tarefa> Obter(string login)
        {
            return _tarefaRepository.GetFiltered(x => x.Usuario.Login == login).ToList();
        }

        public BusinessResponse<bool> Salvar(Tarefa item)
        {
            bool salvo = false;
            string msg = Messages.ValidationGenerico;

            var erros = item.FazerSeForValido<Tarefa>(() =>
                {
                    if (item.Id.HasValue)
                    {
                        Tarefa tarefa = _tarefaRepository.Get(item.Id.Value);
                        if (tarefa != null)
                        {
                            tarefa.Descricao = item.Descricao;

                            _tarefaRepository.Modify(tarefa);
                            salvo = (_tarefaRepository.UnitOfWork.Commit() > 0);

                            if (salvo)
                                msg = Messages.ValidationTarefaAlteradaSucesso;
                        }
                        else
                        {
                            msg = Messages.ValidationTarefaNaoExiste;
                        }
                    }
                    else
                    {
                        _tarefaRepository.Add(item);
                        salvo = (_tarefaRepository.UnitOfWork.Commit() > 0);

                        if (salvo)
                            msg = Messages.ValidationTarefaSalvaSucesso;
                    }
                });

            if (erros.ExistemErros())
                msg = erros.FirstOrDefault();

            return new BusinessResponse<bool>(salvo, msg);
        }

        public BusinessResponse<bool> Excluir(int id)
        {
            Tarefa tarefa = _tarefaRepository.Get(id);

            if (tarefa == null)
                return new BusinessResponse<bool>(false, Messages.ValidationTarefaNaoExiste);

            _tarefaRepository.Remove(tarefa);
            bool excluido = (_tarefaRepository.UnitOfWork.Commit() > 0);

            if (excluido)
                return new BusinessResponse<bool>(true, Messages.ValidationTarefaExcluidaSucesso);

            return new BusinessResponse<bool>(false, Messages.ValidationGenerico);
        }

        public BusinessResponse<bool> Executar(int id)
        {
            Tarefa tarefa = _tarefaRepository.Get(id);

            if (tarefa == null)
                return new BusinessResponse<bool>(false, Messages.ValidationTarefaNaoExiste);

            tarefa.Executada = true;

            _tarefaRepository.Modify(tarefa);
            bool alterada = (_tarefaRepository.UnitOfWork.Commit() > 0);

            if (alterada)
                return new BusinessResponse<bool>(true, Messages.ValidationTarefaAlteradaSucesso);

            return new BusinessResponse<bool>(false, Messages.ValidationGenerico);
        }

        #endregion
    }
}
