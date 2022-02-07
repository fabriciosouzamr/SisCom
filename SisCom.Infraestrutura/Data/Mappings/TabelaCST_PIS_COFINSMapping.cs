using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class TabelaCST_PIS_COFINSMapping : IEntityTypeConfiguration<TabelaCST_PIS_COFINS>
    {
        public void Configure(EntityTypeBuilder<TabelaCST_PIS_COFINS> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.ToTable("TabelaCST_PIS_COFINSs");
        }
    }
}
