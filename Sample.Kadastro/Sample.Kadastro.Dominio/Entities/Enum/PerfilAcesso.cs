using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Sample.Kadastro.Dominio.Entities.Enum
{
    public enum PerfilAcesso : int
    {
        [Description("Desenvolvedor")]
        Desenvolvedor = 0,
        [Description("Analista de Requisitos")]
        AnalistaRequisitos = 1,
        [Description("Analista de Qualidade")]
        AnalistaQualidade = 2,
        [Description("Analista de Requisito/Qualidade")]
        AnalistaRequisitoQualidade = 3
    }
}
