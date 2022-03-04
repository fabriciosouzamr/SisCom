using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(x => x.Endereco);

            builder.Property(p => p.CNPJ_CPF)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.RazaoSocial)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Codigo)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            builder.Property(p => p.InscricaoEstadual)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.RG)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.InscricaoMunicipal)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.NomeContato)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.FAX)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.EMail)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Site)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Representante)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Observacoes)
                .HasColumnType("text");

            builder.Property(p => p.Imagem)
                .HasColumnType("image");

            builder.Property(p => p.VendedorId)
                .IsRequired(false);

            builder.ToTable("Pessoas");
        }
    }
}
