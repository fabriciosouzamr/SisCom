using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class UnidadeMedidaConversaoMapping : IEntityTypeConfiguration<UnidadeMedidaConversao>
    {
        public void Configure(EntityTypeBuilder<UnidadeMedidaConversao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Conversor)
                .IsRequired()
                .HasColumnType("decimal(14, 10)");

            builder.ToTable("UnidadeMedidaConversoes");
        }
    }
}