using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Kadastro.Dominio
{
    // Referências:
    // http://martinfowler.com/eaaCatalog/unitOfWork.html
    // http://msdn.microsoft.com/en-us/magazine/dd882510.aspx
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        void CommitAndRefreshChanges();
        void RollbackChanges();
    }
}
