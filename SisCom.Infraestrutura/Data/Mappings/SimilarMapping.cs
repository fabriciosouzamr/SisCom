using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SisCom.Infraestrutura.Mappings
{
    public class SimilarMapping : IEntityTypeConfiguration<Similar>
    {
        public void Configure(EntityTypeBuilder<Similar> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Similares");
        }
    }
}
