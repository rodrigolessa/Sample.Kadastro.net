using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Sample.Kadastro.Dominio.Models.Mapping
{
    public class usuarioMap : EntityTypeConfiguration<usuario>
    {
        public usuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.login)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.senha)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.email)
                .HasMaxLength(100);

            this.Property(t => t.status)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("usuario");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.login).HasColumnName("login");
            this.Property(t => t.senha).HasColumnName("senha");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.status).HasColumnName("status");
        }
    }
}
