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

            builder.ToTable("NotaFiscalSaidaMercadorias");
        }
    }
}
