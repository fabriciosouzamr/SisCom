using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class MercadoriaFornecedorMapping : IEntityTypeConfiguration<MercadoriaFornecedor>
    {
        public void Configure(EntityTypeBuilder<MercadoriaFornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CodigoFonecedor)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("MercadoriaFornecedores");
        }
    }
}
