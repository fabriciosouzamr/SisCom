using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class ManifestoEletronicoDocumentoMapping : IEntityTypeConfiguration<ManifestoEletronicoDocumento>
    {
        public void Configure(EntityTypeBuilder<ManifestoEletronicoDocumento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Numero).IsRequired().HasColumnType("varchar(20)");

            builder.Property(p => p.DadoVeiculo_NumeroPlaca).IsRequired().HasColumnType("varchar(10)");

            builder.Property(p => p.Carga).HasColumnType("varchar(8)");
            builder.Property(p => p.RNTRCEmitente).HasColumnType("varchar(10)");
            builder.Property(p => p.DadoVeiculo_Renavam).HasColumnType("varchar(10)");
            builder.Property(p => p.DadoVeiculoVeiculoTerceiros_NomeProprietario).HasColumnType("varchar(100)");
            builder.Property(p => p.DadoVeiculoVeiculoTerceiros_CPFCNPJProprietario).HasColumnType("varchar(14)");
            builder.Property(p => p.DadoVeiculoVeiculoTerceiros_IEProprietario).HasColumnType("varchar(15)");
            builder.Property(p => p.DadoVeiculoVeiculoTerceiros_RNTRCProprietario).HasColumnType("varchar(10)");
            builder.Property(p => p.Autorizacao_ChaveAutenticacao).HasColumnType("varchar(44)");
            builder.Property(p => p.Autorizacao_Protocolo).HasColumnType("varchar(44)");
            builder.Property(p => p.Condutor_CPF).HasColumnType("varchar(14)");
            builder.Property(p => p.Condutor_Nome).HasColumnType("varchar(100)");
            builder.Property(p => p.InformacoesAdicionaisInteresseFisco).HasColumnType("varchar(8000)");
            builder.Property(p => p.InformacoesComplementaresInteresseContribuinte).HasColumnType("varchar(8000)");
            ;
            builder.Property(p => p.RetornoSefaz).HasColumnType("varchar(8000)");

            builder.ToTable("ManifestoEletronicoDocumentos");
        }
    }
}
