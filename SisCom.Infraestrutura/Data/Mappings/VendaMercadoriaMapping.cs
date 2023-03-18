using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    internal class VendaMercadoriaMapping : IEntityTypeConfiguration<VendaMercadoria>
    {
        public void Configure(EntityTypeBuilder<VendaMercadoria> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Preco).HasColumnType("decimal(18, 8)");
            builder.Property(p => p.Total).HasColumnType("decimal(18, 8)");

            builder.ToTable("VendaMercadorias");
        }
    }
}