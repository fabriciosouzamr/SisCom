using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class NotaFiscalEntradaMercadoriaMapping : IEntityTypeConfiguration<NotaFiscalEntradaMercadoria>
    {
        public void Configure(EntityTypeBuilder<NotaFiscalEntradaMercadoria> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("NotaFiscalEntradaMercadorias");
        }
    }
}