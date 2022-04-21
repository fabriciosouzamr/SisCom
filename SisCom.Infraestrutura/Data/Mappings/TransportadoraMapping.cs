using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class TransportadoraMapping : IEntityTypeConfiguration<Transportadora>
    {
        public void Configure(EntityTypeBuilder<Transportadora> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(x => x.Endereco);

            builder.Property(p => p.CNPJ_CPF)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.InscricaoEstadual)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.NomeContato)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.PlacaVeiculo)
                .HasColumnType("varchar(9)");

            builder.Property(p => p.PlacaCarreta01)
                .HasColumnType("varchar(9)");

            builder.Property(p => p.PlacaCarreta02)
                .HasColumnType("varchar(9)");

            builder.ToTable("Transportadoras");
        }
    }
}
