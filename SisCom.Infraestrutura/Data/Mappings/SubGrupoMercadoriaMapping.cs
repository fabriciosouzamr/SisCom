using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SisCom.Infraestrutura.Mappings
{
    public class SubGrupoMercadoriaMapping : IEntityTypeConfiguration<SubGrupoMercadoria>
    {
        public void Configure(EntityTypeBuilder<SubGrupoMercadoria> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("SubGrupoMercadorias");
        }
    }
}
