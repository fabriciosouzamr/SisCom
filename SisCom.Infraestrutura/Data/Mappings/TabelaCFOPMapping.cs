using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class CFOPMapping : IEntityTypeConfiguration<TabelaCFOP>
    {
        public void Configure(EntityTypeBuilder<TabelaCFOP> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(400)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(4)");

            builder.ToTable("TabelaCFOPs");
        }
    }
}
