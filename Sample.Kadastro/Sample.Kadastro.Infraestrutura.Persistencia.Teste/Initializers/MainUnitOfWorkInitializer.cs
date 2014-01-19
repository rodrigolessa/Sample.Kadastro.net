using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Common;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Infraestrutura.Persistencia.Teste.Initializers
{
    public class MainUnitOfWorkInitializer : DropCreateDatabaseAlways<MainUnitOfWork>
    {
        private const string _QUERY_IMPORTACAO_USUARIO = "insert into {kadastro}.dbo.usuario(Login, Senha, Email, Status) VALUES () ";

        protected override void Seed(MainUnitOfWork unitOfWork)
        {
            string queryImportacaoUsuario = _QUERY_IMPORTACAO_USUARIO.Replace("{kadastro}", "kadastro_teste");

            unitOfWork.ExecuteCommand(queryImportacaoUsuario);
        }
    }
}
