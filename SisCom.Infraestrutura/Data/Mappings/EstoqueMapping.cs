using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.AlmoxarifadoId)
                .IsRequired();

            builder.Property(p => p.MercadoriaId)
                .IsRequired();

            builder.Property(p => p.QuantidadeEmEstoque)
                .IsRequired();

            builder.ToTable("Estoques");
        }
    }
}