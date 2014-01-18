using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Sample.Kadastro.Dominio.Entities.Enum;

namespace Sample.Kadastro.Dominio.Entities
{
    public partial class Usuario : EntityBase, IValidatableObject
    {
        public virtual PerfilAcesso? PerfilAcesso { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Login))
                validationResults.Add(new ValidationResult(Messages.ValidationUsuarioLoginNaoPodeSerNulo));

            if (string.IsNullOrWhiteSpace(this.Senha))
                validationResults.Add(new ValidationResult(Messages.ValidationUsuarioSenhaNaoPodeSerNulo));

            if (!this.PerfilAcesso.HasValue)
                validationResults.Add(new ValidationResult(Messages.ValidationUsuarioPerfilAcessoNaoPodeSerNulo));

            return validationResults;
        }
    }
}
