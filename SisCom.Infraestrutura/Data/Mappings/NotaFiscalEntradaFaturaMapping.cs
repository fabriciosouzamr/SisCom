using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class NotaFiscalEntradaFaturaMapping : IEntityTypeConfiguration<NotaFiscalEntradaFatura>
    {
        public void Configure(EntityTypeBuilder<NotaFiscalEntradaFatura> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Observacao)
                .HasColumnType("text");

            builder.ToTable("NotaFiscalEntradaFaturas");
        }
    }
}