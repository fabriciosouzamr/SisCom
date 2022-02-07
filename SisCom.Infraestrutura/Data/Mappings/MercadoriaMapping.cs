using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class MercadoriaMapping : IEntityTypeConfiguration<Mercadoria>
    {
        public void Configure(EntityTypeBuilder<Mercadoria> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.CodigoFabricante)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.CodigoBarra)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Preco_PrecoCompra)
                .HasColumnType("money");

            builder.Property(p => p.Preco_ICMS_Compra)
                .HasColumnType("money");

            builder.Property(p => p.Preco_ICMS_Fronteira)
                .HasColumnType("money");

            builder.Property(p => p.Preco_IPI)
                .HasColumnType("money");

            builder.Property(p => p.Preco_Frete)
                .HasColumnType("money");

            builder.Property(p => p.Preco_Embalagem)
                .HasColumnType("money");

            builder.Property(p => p.Preco_EncFinanceiro)
                .HasColumnType("money");

            builder.Property(p => p.Preco_CustoMercadoria)
                .HasColumnType("money");

            builder.Property(p => p.Preco_CustoFixo)
                .HasColumnType("money");

            builder.Property(p => p.Preco_ImpostoFederais)
                .HasColumnType("money");

            builder.Property(p => p.Preco_ICMS_Venda)
                .HasColumnType("money");

            builder.Property(p => p.Preco_Comissao)
                .HasColumnType("money");

            builder.Property(p => p.Preco_Marketing)
                .HasColumnType("money");

            builder.Property(p => p.Preco_OutrosCustos)
                .HasColumnType("money");

            builder.Property(p => p.Preco_PontoEquilibrio)
                .HasColumnType("money");

            builder.Property(p => p.Preco_MargemSugerido)
                .HasColumnType("money");

            builder.Property(p => p.Preco_PrecoSugerido)
                .HasColumnType("money");

            builder.Property(p => p.Preco_MargemVenda)
                .HasColumnType("money");

            builder.Property(p => p.Preco_PrecoVenda)
                .HasColumnType("money");

            builder.Property(p => p.Preco_MargemA)
                .HasColumnType("money");

            builder.Property(p => p.Preco_PrecoA)
                .HasColumnType("money");

            builder.Property(p => p.Preco_MargemB)
                .HasColumnType("money");

            builder.Property(p => p.Preco_PrecoB)
                .HasColumnType("money");

            builder.Property(p => p.Preco_MargemC)
                .HasColumnType("money");

            builder.Property(p => p.Preco_PrecoC)
                .HasColumnType("money");

            builder.Property(p => p.Preco_CalculoPreco)
                .HasColumnType("money");

            builder.Property(p => p.Preco_CalculoPrecificacao)
                .HasColumnType("money");

            builder.Property(p => p.Fiscal_CodigoAnvisa)
                .HasColumnType("varchar(13)");

            builder.Property(p => p.Fiscal_InformacaoAdicional)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Estoque_Pratileira)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Estoque_TributacaoNFCe_TipoServicoMunicipal)
                .HasColumnType("varchar(10)");

            builder.Property(p => p.FotoEspecificacao_Especificacao)
                .HasColumnType("text");

            builder.Property(p => p.FotoEspecificacao_URL)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.FotoEspecificacao_Imagem_ContentType)
                .HasMaxLength(20);

            builder.ToTable("Mercadorias");
        }
    }
}
