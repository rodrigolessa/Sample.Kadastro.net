using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Kadastro.Infraestrutura.Comuns.Validator
{
    public class DataAnnotationsEntityValidatorFactory : IEntityValidatorFactory
    {
        public IEntityValidator Create()
        {
            return new DataAnnotationsEntityValidator();
        }
    }
}
