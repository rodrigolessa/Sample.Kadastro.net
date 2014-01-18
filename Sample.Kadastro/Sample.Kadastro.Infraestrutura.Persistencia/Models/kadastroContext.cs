using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Sample.Kadastro.Infraestrutura.Persistencia.Models.Mapping;

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
            modelBuilder.Configurations.Add(new IntervaloMap());
            modelBuilder.Configurations.Add(new PontoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
