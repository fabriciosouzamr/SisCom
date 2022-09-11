using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class NotaFiscalSaidaSerieMapping : IEntityTypeConfiguration<NotaFiscalSaidaSerie>
    {
        public void Configure(EntityTypeBuilder<NotaFiscalSaidaSerie> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UltimaNotaFiscal).IsRequired().HasColumnType("varchar(10)").HasDefaultValue("0");
            builder.Property(p => p.Serie).IsRequired().HasColumnType("varchar(3)");

            builder.ToTable("NotaFiscalSaidaSeries");
        }
    }
}