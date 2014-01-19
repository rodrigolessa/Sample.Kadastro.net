using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Kadastro.Infraestrutura.Comuns.Validator
{
    public interface IEntityValidatorFactory
    {
        IEntityValidator Create();
    }
}
