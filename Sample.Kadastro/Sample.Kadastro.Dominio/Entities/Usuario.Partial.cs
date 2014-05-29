using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Sample.Kadastro.Infraestrutura.Comuns.Extensions;
using Sample.Kadastro.Dominio.Entities.Enum;

namespace Sample.Kadastro.Dominio.Entities
{
    public partial class Usuario : EntityBase, IValidatableObject
    {
        //public virtual PerfilAcesso? PerfilAcesso { get; set; }

        public virtual string DescricaoDoStatus
        {
            get
            {
                string descricao = string.Empty;

                if (!string.IsNullOrEmpty(this.Status))
                {
                    switch (Convert.ToChar(this.Status))
                    {
                        case (char)StatusUsuario.Ativo:
                            descricao = StatusUsuario.Ativo.ToString();
                            break;
                        case (char)StatusUsuario.Inativo:
                            descricao = StatusUsuario.Inativo.ToString();
                            break;
                        case (char)StatusUsuario.Pendente:
                            descricao = StatusUsuario.Pendente.ToString();
                            break;
                    }
                }

                return descricao;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Login))
                validationResults.Add(new ValidationResult(Messages.ValidationUsuarioLoginNaoPodeSerNulo));

            if (string.IsNullOrWhiteSpace(this.Senha))
                validationResults.Add(new ValidationResult(Messages.ValidationUsuarioSenhaNaoPodeSerNulo));

            //if (!this.PerfilAcesso.HasValue)
            //validationResults.Add(new ValidationResult(Messages.ValidationUsuarioPerfilAcessoNaoPodeSerNulo));

            return validationResults;
        }
    }
}
