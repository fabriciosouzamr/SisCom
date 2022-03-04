using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(x => x.Endereco);

            builder.Property(p => p.Unidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.RazaoSocial)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.NomeFantasia)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.CNPJ)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.InscricaoEstadual)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.InscricaoMunicipal)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.InscricaoEstadual_SubTributaria)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.EMail)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.NFE_VersaoEmissor)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.NFE_Serie)
                .HasColumnType("varchar(2)");

            builder.Property(p => p.MDFe_Serie)
                .HasColumnType("varchar(3)");

            builder.Property(p => p.PathLogomarca)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.NuvemFiscal_Certificado)
                .HasColumnType("varchar(200)");

            builder.ToTable("Empresas");
        }
    }
}
