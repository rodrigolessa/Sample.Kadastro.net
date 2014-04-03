using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Kadastro.Dominio.Entities;

namespace Sample.Kadastro.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class TarefaTypeConfiguration : EntityTypeConfiguration<Tarefa>
    {
        public TarefaTypeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descricao)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Tarefa");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdUsuario).HasColumnName("IdUsuario");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Executada).HasColumnName("Executada");

            // Relationships
            this.HasRequired(t => t.Usuario)
                .WithMany(t => t.Tarefas)
                .HasForeignKey(d => d.IdUsuario);
        }
    }
}
