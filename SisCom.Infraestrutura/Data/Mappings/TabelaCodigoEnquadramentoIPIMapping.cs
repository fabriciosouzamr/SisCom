using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class TabelaCodigoEnquadramentoIPIMapping : IEntityTypeConfiguration<TabelaCodigoEnquadramentoIPI>
    {
        public void Configure(EntityTypeBuilder<TabelaCodigoEnquadramentoIPI> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(3)");

            builder.ToTable("TabelaCodigoEnquadramentoIPIs");
        }
    }
}
