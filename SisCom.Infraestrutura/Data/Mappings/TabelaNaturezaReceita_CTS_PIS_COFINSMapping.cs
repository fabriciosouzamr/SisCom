using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class TabelaNaturezaReceita_CTS_PIS_COFINSMapping : IEntityTypeConfiguration<TabelaNaturezaReceita_CTS_PIS_COFINS>
    {
        public void Configure(EntityTypeBuilder<TabelaNaturezaReceita_CTS_PIS_COFINS> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("char(5)");

            builder.ToTable("TabelaNaturezaReceita_CTS_PIS_COFINSs");
        }
    }
}