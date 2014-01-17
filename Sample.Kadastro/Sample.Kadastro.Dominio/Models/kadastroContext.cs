using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Sample.Kadastro.Dominio.Models.Mapping;

namespace Sample.Kadastro.Dominio.Models
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

        public DbSet<intervalo> intervaloes { get; set; }
        public DbSet<ponto> pontoes { get; set; }
        public DbSet<usuario> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new intervaloMap());
            modelBuilder.Configurations.Add(new pontoMap());
            modelBuilder.Configurations.Add(new usuarioMap());
        }
    }
}
