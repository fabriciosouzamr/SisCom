using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class CondutorMapping : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.CNPJ_CPF)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.ToTable("Condutores");
        }
    }
}
