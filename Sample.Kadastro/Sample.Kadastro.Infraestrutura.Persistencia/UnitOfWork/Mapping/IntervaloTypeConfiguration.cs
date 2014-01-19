using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class IntervaloTypeConfiguration : EntityTypeConfiguration<Intervalo>
    {
        public IntervaloTypeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Intervalo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdPonto).HasColumnName("IdPonto");
            this.Property(t => t.Entrada).HasColumnName("Entrada");
            this.Property(t => t.Saida).HasColumnName("Saida");

            // Relationships
            this.HasRequired(t => t.Ponto)
                .WithMany(t => t.Intervalos)
                .HasForeignKey(d => d.IdPonto);
        }
    }
}
