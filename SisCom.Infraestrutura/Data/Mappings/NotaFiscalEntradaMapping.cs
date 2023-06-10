using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class NotaFiscalEntradaMapping : IEntityTypeConfiguration<NotaFiscalEntrada>
    {
        public void Configure(EntityTypeBuilder<NotaFiscalEntrada> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NotaFiscal)
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Serie)
                .HasColumnType("varchar(3)");

            builder.Property(p => p.CodigoChaveAcesso)
                .HasColumnType("varchar(44)");

            builder.Property(p => p.Importacao_NumeroDrawback)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Importacao_NumeroDocumento)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.ServicosAquisicao_CodigoChaveAcesso)
                .HasColumnType("varchar(44)");

            builder.Property(p => p.ServicosAquisicao_Serie)
                .HasColumnType("varchar(3)");

            builder.Property(p => p.ServicosAquisicao_SubSerie)
                .HasColumnType("varchar(3)");

            builder.Property(p => p.xml)
                .HasColumnType("varchar(max)");

            builder.ToTable("NotaFiscalEntradas");
        }
    }
}
