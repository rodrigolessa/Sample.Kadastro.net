using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Sample.Kadastro.Dominio.Entities.Enum
{
    public enum StatusUsuario
    {
        [Description("Ativo")]
        Ativo = 'A',
        [Description("Pendente")]
        Pendente = 'P',
        [Description("Inativo")]
        Inativo = 'I'
    }
}
