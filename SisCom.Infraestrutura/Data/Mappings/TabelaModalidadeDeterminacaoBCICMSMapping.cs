using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class TabelaModalidadeDeterminacaoBCICMSMapping : IEntityTypeConfiguration<TabelaModalidadeDeterminacaoBCICMS>
    {
        public void Configure(EntityTypeBuilder<TabelaModalidadeDeterminacaoBCICMS> builder)
        {
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(1)");

            builder.ToTable("TabelaModalidadeDeterminacaoBCICMSs");
        }
    }
}
