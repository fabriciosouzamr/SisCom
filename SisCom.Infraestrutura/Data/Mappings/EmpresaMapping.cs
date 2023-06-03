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

            builder.Property(p => p.Unidade).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.RazaoSocial).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.NomeFantasia).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.CNPJ).IsRequired().HasColumnType("varchar(14)");
            builder.Property(p => p.InscricaoEstadual).HasColumnType("varchar(15)");
            builder.Property(p => p.InscricaoMunicipal).HasColumnType("varchar(15)");
            builder.Property(p => p.InscricaoEstadual_SubTributaria).HasColumnType("varchar(15)");
            builder.Property(p => p.Telefone).HasColumnType("varchar(20)");
            builder.Property(p => p.EMail).HasColumnType("varchar(100)");
            builder.Property(p => p.NFE_VersaoEmissor).HasColumnType("varchar(20)");
            builder.Property(p => p.NFE_Serie).HasColumnType("varchar(2)");
            builder.Property(p => p.MDFe_Serie).HasColumnType("varchar(3)");
            builder.Property(p => p.NFE_InfComple_CreditoSimplesNacional).HasColumnType("varchar(1000)");
            builder.Property(p => p.NFE_InfComple_TributosTotal).HasColumnType("varchar(1000)");
            builder.Property(p => p.PathLogomarca).HasColumnType("varchar(200)");
            builder.Property(p => p.NuvemFiscal_Certificado).HasColumnType("varchar(8000)");
            builder.Property(p => p.NSU).HasColumnType("varchar(10)");
            builder.Property(p => p.Controle).HasColumnType("varchar(1000)");
            builder.Property(p => p.EspeciePadrao).HasColumnType("varchar(200)");
            builder.Property(p => p.MarcaPadrao).HasColumnType("varchar(200)");
            builder.Property(p => p.Responsaveltecnico_CNPJ).HasColumnType("varchar(14)");
            builder.Property(p => p.Responsaveltecnico_Email).HasColumnType("varchar(100)");
            builder.Property(p => p.Responsaveltecnico_Fone).HasColumnType("varchar(20)");
            builder.Property(p => p.Responsaveltecnico_Contato).HasColumnType("varchar(100)");

            builder.ToTable("Empresas");
        }
    }
}
