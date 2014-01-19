using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Kadastro.Dominio;
using Sample.Kadastro.Dominio.Entities;
using Sample.Kadastro.Dominio.Repositories;
using Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork;

namespace Sample.Kadastro.Infraestrutura.Persistencia.Repositories
{
    public partial class PontoRepository : Repository<Ponto>, IPontoRepository
    {
        #region Construtor

        /// <summary>
        /// Cria uma Nova Instância
        /// </summary>
        /// <param name="unitOfWork">Associado ao Unit Of Work</param>
        public PontoRepository(MainUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}
