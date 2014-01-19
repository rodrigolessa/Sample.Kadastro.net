using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork.Mapping;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Infraestrutura.Persistencia.Models
{
    public partial class kadastroContext : DbContext
    {
        static kadastroContext()
        {
            Database.SetInitializer<kadastroContext>(null);
        }

        public kadastroContext()
            : base("Name=kadastroContext")
        {
        }

        public DbSet<Intervalo> Intervalos { get; set; }
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IntervaloTypeConfiguration());
            modelBuilder.Configurations.Add(new PontoTypeConfiguration());
            modelBuilder.Configurations.Add(new UsuarioTypeConfiguration());
        }
    }
}
