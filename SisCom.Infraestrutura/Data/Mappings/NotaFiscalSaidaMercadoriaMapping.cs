using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class NotaFiscalSaidaMercadoriaMapping : IEntityTypeConfiguration<NotaFiscalSaidaMercadoria>
    {
        public void Configure(EntityTypeBuilder<NotaFiscalSaidaMercadoria> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Quantidade).HasColumnType("decimal(18, 8)");
            builder.Property(p => p.PrecoUnitario).HasColumnType("decimal(18, 8)");
            builder.Property(p => p.PrecoTotal).HasColumnType("decimal(18, 8)");
            builder.Property(p => p.ValorBaseSubstituicaoTributaria).HasColumnType("decimal(18, 8)");
            builder.Property(p => p.ValorBaseCalculo).HasColumnType("decimal(18, 8)");
            builder.Property(p => p.ValorSubstituicaoTributaria).HasColumnType("decimal(18, 8)");

            builder.ToTable("NotaFiscalSaidaMercadorias");
        }
    }
}
