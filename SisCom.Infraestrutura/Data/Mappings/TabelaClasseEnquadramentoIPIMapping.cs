using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class TabelaClasseEnquadramentoIPIMapping : IEntityTypeConfiguration<TabelaClasseEnquadramentoIPI>
    {
        public void Configure(EntityTypeBuilder<TabelaClasseEnquadramentoIPI> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(5)");

            builder.ToTable("TabelaClasseEnquadramentoIPIs");
        }
    }
}
