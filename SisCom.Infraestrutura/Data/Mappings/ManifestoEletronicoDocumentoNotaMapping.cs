using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class ManifestoEletronicoDocumentoNotaMapping : IEntityTypeConfiguration<ManifestoEletronicoDocumentoNota>
    {
        public void Configure(EntityTypeBuilder<ManifestoEletronicoDocumentoNota> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NumeroNotaFiscal).HasColumnType("varchar(20)");
            builder.Property(p => p.ChaveAcesso).HasColumnType("varchar(44)");

            builder.ToTable("ManifestoEletronicoDocumentoNotas");
        }
    }
}