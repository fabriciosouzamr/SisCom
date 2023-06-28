using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class MercadoriaUnidadeMedidaConversaoMapping : IEntityTypeConfiguration<MercadoriaUnidadeMedidaConversao>
    {
        public void Configure(EntityTypeBuilder<MercadoriaUnidadeMedidaConversao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FatorConversao)
                .IsRequired()
                .HasDefaultValue(1);

            builder.ToTable("MercadoriaUnidadeMedidaConversaos");
        }
    }
}
