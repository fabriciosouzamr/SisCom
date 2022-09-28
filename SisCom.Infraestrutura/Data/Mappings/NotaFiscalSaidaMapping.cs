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

            builder.OwnsOne(x => x.Cliente_Endereco);

            builder.Property(p => p.NotaFiscal).HasColumnType("varchar(10)");
            builder.Property(p => p.HoraEmissao).HasColumnType("varchar(5)");
            builder.Property(p => p.Modelo).HasColumnType("varchar(2)");
            builder.Property(p => p.Serie).HasColumnType("varchar(3)");
            builder.Property(p => p.SubSerie).HasColumnType("varchar(3)");
            builder.Property(p => p.CNPJ_CPF).HasColumnType("varchar(14)");
            builder.Property(p => p.IE).HasColumnType("varchar(20)");
            builder.Property(p => p.Cliente_Telefone).HasColumnType("varchar(20)");
            builder.Property(p => p.Cliente_EMail).HasColumnType("varchar(200)");
            builder.Property(p => p.Transportadora_CNPJ_CPF).HasColumnType("varchar(14)");
            builder.Property(p => p.Transportadora_Placa).HasColumnType("varchar(10)");
            builder.Property(p => p.Transportadora_RNTRC).HasColumnType("varchar(10)");
            builder.Property(p => p.VolumeTransportados_Especie).HasColumnType("varchar(200)");
            builder.Property(p => p.VolumeTransportados_Marca).HasColumnType("varchar(200)");
            builder.Property(p => p.EmailDestinoXML).HasColumnType("varchar(200)");
            builder.Property(p => p.ObservacaoDocumento).HasColumnType("varchar(8000)");
            builder.Property(p => p.InformacoesAdicionaisInteresseFisco).HasColumnType("varchar(8000)");
            builder.Property(p => p.InformacoesComplementaresInteresseContribuinte_Obsersacao).HasColumnType("varchar(8000)");
            builder.Property(p => p.CodigoChaveAcesso).HasColumnType("varchar(44)");
            builder.Property(p => p.Protocolo).HasColumnType("varchar(40)");
            builder.Property(p => p.RetornoSefaz).HasColumnType("varchar(8000)");
            builder.Property(p => p.RetornoSefazCodigo).HasColumnType("varchar(10)");

            builder.ToTable("NotaFiscalSaidas");
        }
    }
}
