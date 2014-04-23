using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Infraestrutura.Comuns;
using Sample.Kadastro.Aplicacao.DTO;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Aplicacao
{
    public interface ITarefaAppService
    {
        List<TarefaDTO> Obter(string login);
        BusinessResponse<Boolean> Salvar(TarefaDTO item);
        BusinessResponse<Boolean> Excluir(Int32 id);
        BusinessResponse<Boolean> Executar(Int32 id);
    }
}
