using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class EstoqueLancamentoMapping : IEntityTypeConfiguration<EstoqueLancamento>
    {
        public void Configure(EntityTypeBuilder<EstoqueLancamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.EstoqueId)
                .IsRequired();

            builder.Property(p => p.EntradaSaida)
                .IsRequired();

            builder.Property(p => p.Data)
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .IsRequired();

            builder.Property(p => p.Comentario)
                .IsRequired(false)
                .HasColumnType("varchar(1000)");

            builder.ToTable("EstoqueLancamentos");
        }
    }
}
