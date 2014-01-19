using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Kadastro.Infraestrutura.Comuns.Validator
{
    public interface IEntityValidator
    {
        bool IsValid<TEntity>(TEntity item)
            where TEntity : class;

        IEnumerable<String> GetInvalidMessages<TEntity>(TEntity item)
            where TEntity : class;
    }
}
