using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class UsuarioTypeConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioTypeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Login)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Status)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("Usuario");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Login).HasColumnName("Login");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
