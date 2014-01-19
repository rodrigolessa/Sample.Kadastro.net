using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class PontoTypeConfiguration : EntityTypeConfiguration<Ponto>
    {
        public PontoTypeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Ponto");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdUsuario).HasColumnName("IdUsuario");
            this.Property(t => t.Dia).HasColumnName("Dia");
            this.Property(t => t.Horas).HasColumnName("Horas");

            // Relationships
            this.HasRequired(t => t.Usuario)
                .WithMany(t => t.Pontos)
                .HasForeignKey(d => d.IdUsuario);
        }
    }
}
