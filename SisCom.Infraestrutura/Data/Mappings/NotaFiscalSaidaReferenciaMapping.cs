using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class NotaFiscalSaidaReferenciaMapping : IEntityTypeConfiguration<NotaFiscalSaidaReferencia>
    {
        public void Configure(EntityTypeBuilder<NotaFiscalSaidaReferencia> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NotaFiscal)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.CodigoChaveAcesso)
                .IsRequired()
                .HasColumnType("varchar(44)");

            builder.ToTable("NotaFiscalSaidaReferencias");
        }
    }
}