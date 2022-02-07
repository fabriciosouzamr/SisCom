using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class TabelaCST_CSOSNMapping : IEntityTypeConfiguration<TabelaCST_CSOSN>
    {
        public void Configure(EntityTypeBuilder<TabelaCST_CSOSN> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(3)");

            builder.Property(p => p.ST)
                .HasColumnType("varchar(2)");

            builder.Property(p => p.CSTEquivalente)
                .HasColumnType("varchar(3)");

            builder.ToTable("TabelaCST_CSOSNs");
        }
    }
}
