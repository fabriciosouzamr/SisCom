using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class CNAETabelaCNAEMapping : IEntityTypeConfiguration<TabelaCNAE>
    {
        public void Configure(EntityTypeBuilder<TabelaCNAE> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(7)");

            builder.ToTable("TabelaCNAEs");
        }
    }
}
