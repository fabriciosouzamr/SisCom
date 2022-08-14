using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class VeiculoPlacaMapping : IEntityTypeConfiguration<VeiculoPlaca>
    {
        public void Configure(EntityTypeBuilder<VeiculoPlaca> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NumeroPlaca)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.CodigoRenavan)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.ToTable("VeiculoPlacas");
        }
    }
}
