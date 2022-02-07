using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class TabelaMotivoDesoneracaoICMSMapping : IEntityTypeConfiguration<TabelaMotivoDesoneracaoICMS>
    {
        public void Configure(EntityTypeBuilder<TabelaMotivoDesoneracaoICMS> builder)
        {
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.ToTable("TabelaMotivoDesoneracaoICMSs");
        }
    }
}
