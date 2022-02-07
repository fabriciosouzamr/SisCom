using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class TabelaSituacaoTributariaNFCeMapping : IEntityTypeConfiguration<TabelaSituacaoTributariaNFCe>
    {
        public void Configure(EntityTypeBuilder<TabelaSituacaoTributariaNFCe> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("char(2)");

            builder.ToTable("TabelaSituacaoTributariaNFCes");
        }
    }
}
