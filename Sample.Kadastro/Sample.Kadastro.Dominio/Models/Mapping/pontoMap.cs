using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Sample.Kadastro.Dominio.Models.Mapping
{
    public class pontoMap : EntityTypeConfiguration<ponto>
    {
        public pontoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ponto");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idUsuario).HasColumnName("idUsuario");
            this.Property(t => t.dia).HasColumnName("dia");
            this.Property(t => t.horas).HasColumnName("horas");

            // Relationships
            this.HasRequired(t => t.usuario)
                .WithMany(t => t.pontoes)
                .HasForeignKey(d => d.idUsuario);

        }
    }
}
