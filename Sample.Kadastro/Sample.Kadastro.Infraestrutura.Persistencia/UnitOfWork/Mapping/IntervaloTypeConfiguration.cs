using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class IntervaloTypeConfiguration
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
