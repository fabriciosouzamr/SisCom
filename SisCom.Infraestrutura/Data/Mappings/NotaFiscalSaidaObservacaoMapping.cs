using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class NotaFiscalSaidaObservacaoMapping : IEntityTypeConfiguration<NotaFiscalSaidaObservacao>
    {
        public void Configure(EntityTypeBuilder<NotaFiscalSaidaObservacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.ToTable("NotaFiscalSaidaObservacaos");
        }
    }
}
