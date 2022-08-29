using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class NotaFiscalSaidaMapping : IEntityTypeConfiguration<NotaFiscalSaida>
    {
        public void Configure(EntityTypeBuilder<NotaFiscalSaida> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(x => x.Endereco);

            builder.Property(p => p.NotaFiscal).IsRequired().HasColumnType("varchar(10)");
            builder.Property(p => p.HoraEmissao).IsRequired().HasColumnType("varchar(5)");
            builder.Property(p => p.Modelo).IsRequired().HasColumnType("varchar(2)");
            builder.Property(p => p.Serie).IsRequired().HasColumnType("varchar(3)");
            builder.Property(p => p.SubSerie).IsRequired().HasColumnType("varchar(3)");
            builder.Property(p => p.CNPJ_CPF).IsRequired().HasColumnType("varchar(14)");
            builder.Property(p => p.IE).IsRequired().HasColumnType("varchar(20)");
            builder.Property(p => p.Telefone).IsRequired().HasColumnType("varchar(20)");
            builder.Property(p => p.EMail).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.Transportadora_CNPJ_CPF).IsRequired().HasColumnType("varchar(14)");
            builder.Property(p => p.Transportadora_Placa).IsRequired().HasColumnType("varchar(10)");
            builder.Property(p => p.Transportadora_RNTRC).IsRequired().HasColumnType("varchar(10)");
            builder.Property(p => p.VolumeTransportados_Especie).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.VolumeTransportados_Marca).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.EmailDestinoXML).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.ObservacaoDocumento).IsRequired().HasColumnType("varchar(8000)");
            builder.Property(p => p.InformacoesAdicionaisInteresseFisco).IsRequired().HasColumnType("varchar(8000)");
            builder.Property(p => p.InformacoesComplementaresInteresseContribuinte_Obsersacao).IsRequired().HasColumnType("varchar(8000)");
            builder.Property(p => p.CodigoChaveAcesso).IsRequired().HasColumnType("varchar(44)");
            builder.Property(p => p.Protocolo).IsRequired().HasColumnType("varchar(40)");
            
            builder.ToTable("NotaFiscalSaidas");
        }
    }
}
