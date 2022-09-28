using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class VendaMapping : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Observacao)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            builder.ToTable("Vendas");
        }
    }
}
