using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SisCom.Infraestrutura.Mappings
{
    public class GrupoMercadoriaMapping : IEntityTypeConfiguration<GrupoMercadoria>
    {
        public void Configure(EntityTypeBuilder<GrupoMercadoria> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.ToTable("GrupoMercadorias");
        }
    }
}
