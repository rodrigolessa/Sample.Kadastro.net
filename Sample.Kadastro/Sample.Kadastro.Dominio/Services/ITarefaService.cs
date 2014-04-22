using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Infraestrutura.Comuns;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Entities.Enum;
using Sample.Kadastro.Dominio.Model;

namespace Sample.Kadastro.Dominio.Services
{
    public interface ITarefaService
    {
        List<Tarefa> Obter(string login);
        BusinessResponse<Boolean> Salvar(Tarefa item);
        BusinessResponse<Boolean> Excluir(Int32 id);
        BusinessResponse<Boolean> Executar(Int32 id);
    }
}
