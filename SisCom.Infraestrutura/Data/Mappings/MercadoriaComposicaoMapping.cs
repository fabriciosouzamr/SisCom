using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class MercadoriaComposicaoMapping : IEntityTypeConfiguration<MercadoriaImpostoEstado>
    {
        public void Configure(EntityTypeBuilder<MercadoriaImpostoEstado> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("MercadoriaImpostoEstados");
        }
    }
}
