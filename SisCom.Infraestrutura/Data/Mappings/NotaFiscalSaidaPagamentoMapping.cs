using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class NotaFiscalSaidaPagamentoMapping : IEntityTypeConfiguration<NotaFiscalSaidaPagamento>
    {
        public void Configure(EntityTypeBuilder<NotaFiscalSaidaPagamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("NotaFiscalSaidaPagamentos");
        }
    }
}
