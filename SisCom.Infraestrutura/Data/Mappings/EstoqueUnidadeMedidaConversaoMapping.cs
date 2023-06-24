using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class EstoqueUnidadeMedidaConversaoMapping : IEntityTypeConfiguration<EstoqueUnidadeMedidaConversao>
    {
        public void Configure(EntityTypeBuilder<EstoqueUnidadeMedidaConversao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FatorConversao)
                .IsRequired()
                .HasDefaultValue(1);

            builder.ToTable("EstoqueUnidadeMedidaConversaos");
        }
    }
}
