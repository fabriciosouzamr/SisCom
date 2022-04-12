using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class SubGrupoNaturezaReceita_CTS_PIS_COFINSMapping : IEntityTypeConfiguration<SubGrupoNaturezaReceita_CTS_PIS_COFINS>
    {
        public void Configure(EntityTypeBuilder<SubGrupoNaturezaReceita_CTS_PIS_COFINS> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("SubGrupoNaturezaReceita_CTS_PIS_COFINSs");
        }
    }
}
