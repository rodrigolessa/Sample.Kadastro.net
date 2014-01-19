using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sample.Kadastro.Infraestrutura.Comuns.Validator
{
    public class DataAnnotationsEntityValidator : IEntityValidator
    {
        #region IEntityValidator membros

        public bool IsValid<TEntity>(TEntity item) where TEntity : class
        {
            if (item == null)
                return false;

            List<string> listaDeErros = new List<string>();

            ObtemErrosDeValidatableObject(item, listaDeErros);

            return !listaDeErros.Any();
        }

        public IEnumerable<string> GetInvalidMessages<TEntity>(TEntity item) where TEntity : class
        {
            List<string> listaDeErros = new List<string>();

            if (item == null)
                return listaDeErros;

            ObtemErrosDeValidatableObject(item, listaDeErros);

            return listaDeErros;
        }

        #endregion

        #region Métodos Privados

        void ObtemErrosDeValidatableObject<TEntity>(TEntity item, List<string> errors) where TEntity : class
        {
            if (typeof(IValidatableObject).IsAssignableFrom(typeof(TEntity)))
            {
                var validationContext = new ValidationContext(item, null, null);

                var validationResults = ((IValidatableObject)item).Validate(validationContext);

                errors.AddRange(validationResults.Select(vr => vr.ErrorMessage));
            }
        }

        #endregion
    }
}
