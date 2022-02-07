using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class GrupoCFOPMapping : IEntityTypeConfiguration<GrupoCFOP>
    {
        public void Configure(EntityTypeBuilder<GrupoCFOP> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("GrupoCFOPs");
        }
    }
}
