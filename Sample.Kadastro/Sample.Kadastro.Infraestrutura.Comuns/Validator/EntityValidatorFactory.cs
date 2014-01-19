using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Kadastro.Infraestrutura.Comuns.Validator
{
    public static class EntityValidatorFactory
    {
        #region Atributos

        static IEntityValidatorFactory _factory = null;

        #endregion

        #region Métodos Públicos

        public static void SetCurrent(IEntityValidatorFactory factory)
        {
            _factory = factory;
        }

        public static IEntityValidator CreateValidator()
        {
            return (_factory != null) ? _factory.Create() : null;
        }

        #endregion
    }
}
