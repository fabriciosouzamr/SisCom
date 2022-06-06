using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class NaturezaOperacaoMapping : IEntityTypeConfiguration<NaturezaOperacao>
    {
        public void Configure(EntityTypeBuilder<NaturezaOperacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("NaturezaOperacoes");
        }
    }
}