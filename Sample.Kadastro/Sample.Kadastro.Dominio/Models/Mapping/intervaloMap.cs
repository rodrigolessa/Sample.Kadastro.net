using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Sample.Kadastro.Dominio.Models.Mapping
{
    public class intervaloMap : EntityTypeConfiguration<intervalo>
    {
        public intervaloMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("intervalo");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idPonto).HasColumnName("idPonto");
            this.Property(t => t.entrada).HasColumnName("entrada");
            this.Property(t => t.saida).HasColumnName("saida");

            // Relationships
            this.HasRequired(t => t.ponto)
                .WithMany(t => t.intervaloes)
                .HasForeignKey(d => d.idPonto);

        }
    }
}
