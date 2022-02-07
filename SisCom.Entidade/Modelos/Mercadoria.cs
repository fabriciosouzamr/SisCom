using Funcoes.Classes;
using System;
using System.Collections.Generic;

namespace SisCom.Entidade.Modelos
{
    public class Mercadoria : Entity
    {
        //public Mercadoria()
        //{
        //    this.Estoques = new HashSet<Estoque>();
        //    this.MercadoriaFornecedores = new HashSet<MercadoriaFornecedor>();
        //    this.MercadoriaComposicaos = new HashSet<MercadoriaComposicao>();
        //    //this.MercadoriaSimilar = new HashSet<MercadoriaSimilares>();
        //    this.MercadoriaSimilares = new HashSet<MercadoriaSimilares>();
        //}
        //public virtual ICollection<Estoque> Estoques { get; set; }
        //public virtual ICollection<MercadoriaFornecedor> MercadoriaFornecedores { get; set; }
        //public virtual ICollection<MercadoriaSimilares> MercadoriaSimilares { get; set; }
        //public virtual ICollection<MercadoriaComposicao> MercadoriaComposicaos { get; set; }

        public string Codigo { get; set; }
        public string CodigoFabricante { get; set; }
        public string CodigoBarra { get; set; }
        public string Nome { get; set; }
        public GrupoMercadoria GrupoMercadoria { get; set; }
        public SubGrupoMercadoria SubGrupoMercadoria { get; set; }
        public Pessoa Fornecedor { get; set; }
        public Pessoa Fabricante { get; set; }
        public int Observacao { get; set; }
        public bool NaoVender { get; set; }
        public bool NaoControlarEstoque { get; set; }
        public bool Ativado { get; set; }
        public decimal Preco_PrecoCompra { get; set; }
        public decimal Preco_ICMS_Compra { get; set; }
        public decimal Preco_ICMS_Fronteira { get; set; }
        public decimal Preco_IPI { get; set; }
        public decimal Preco_Frete { get; set; }
        public decimal Preco_Embalagem { get; set; }
        public decimal Preco_EncFinanceiro { get; set; }
        public decimal Preco_CustoMercadoria { get; set; }
        public decimal Preco_CustoFixo { get; set; }
        public decimal Preco_ImpostoFederais { get; set; }
        public decimal Preco_ICMS_Venda { get; set; }
        public decimal Preco_Comissao { get; set; }
        public decimal Preco_Marketing { get; set; }
        public decimal Preco_OutrosCustos { get; set; }
        public decimal Preco_PontoEquilibrio { get; set; }
        public decimal Preco_MargemSugerido { get; set; }
        public decimal Preco_PrecoSugerido { get; set; }
        public decimal Preco_MargemVenda { get; set; }
        public decimal Preco_PrecoVenda { get; set; }
        public decimal Preco_MargemA { get; set; }
        public decimal Preco_PrecoA { get; set; }
        public decimal Preco_MargemB { get; set; }
        public decimal Preco_PrecoB { get; set; }
        public decimal Preco_MargemC { get; set; }
        public decimal Preco_PrecoC { get; set; }
        public decimal Preco_CalculoPreco { get; set; }
        public decimal Preco_CalculoPrecificacao { get; set; }
        public double Estoque_Quantidade { get; set; }
        public double Estoque_QuantidadeMinimo { get; set; }
        public UnidadeMedida Estoque_Unidade { get; set; }
        public string Estoque_Pratileira { get; set; }
        public double Estoque_PesoBruto { get; set; }
        public double Estoque_PesoLiquido { get; set; }
        public DateTime Estoque_UltimaEntrada { get; set; }
        public DateTime Estoque_AlteracaoPreco { get; set; }
        public TabelaSituacaoTributariaNFCe Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCe { get; set; }
        public double Estoque_TributacaoNFCe_AliquotaICMS { get; set; }
        public TabelaCFOP Estoque_TributacaoNFCe_TabelaCFOP { get; set; }
        public TipoServicoFiscal Estoque_TributacaoNFCe_TipoServicoFiscal { get; set; }
        public string Estoque_TributacaoNFCe_TipoServicoMunicipal { get; set; }
        public VinculoFiscal Fiscal_VinculoFiscal { get; set; }
        public TipoMercadoria Fiscal_TipoMercadoria { get; set; }
        public string Fiscal_InformacaoAdicional { get; set; }
        public TabelaANP Fiscal_TabelaANP { get; set; }
        public string Fiscal_CodigoAnvisa { get; set; }
        public TabelaNCM Fiscal_TabelaNCM { get; set; }
        public TabelaCEST Fiscal_TabelaCEST { get; set; }
        public TabelaOrigemMercadoriaServico Fiscal_TabelaOrigemMercadoriaServico { get; set; }
        public TabelaCST_CSOSN Fiscal_TabelaCST_CSOSN { get; set; }
        public TabelaBeneficioSPED Fiscal_TabelaBeneficioSPED { get; set; }

        //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - IPI          
        public TabelaCST_IPI Fiscal_NFE_TabelaCST_IPI { get; set; }
        public double Fiscal_NFE_IPI_Aliquota { get; set; }

        //Detalhes Fiscais - Informações referente das Notas Fiscais de Entrada - COFINS
        public TabelaCST_PIS_COFINS Fiscal_NFE_TabelaCST_PIS { get; set; }
        public double Fiscal_NFE_PIS_Aliquota { get; set; }
        public TabelaCST_PIS_COFINS Fiscal_NFE_TabelaCST_COFINS { get; set; }
        public double Fiscal_NFE_COFINS_Aliquota { get; set; }
        //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS
        public TabelaModalidadeDeterminacaoBCICMS Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMS { get; set; }
        public double Fiscal_NFS_ICMS_ValorAdicional { get; set; }
        public double Fiscal_NFS_ICMS_Deferimento { get; set; }
        public double Fiscal_NFS_ICMS_ReducaoBase { get; set; }
        public TabelaMotivoDesoneracaoICMS Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMS { get; set; }
        //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - ICMS Substituiçao Tributária
        public TabelaModalidadeDeterminacaoBCICMS Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMS { get; set; }
        public double Fiscal_NFS_ICMSST_ValorAdicional { get; set; }
        public double Fiscal_NFS_ICMSST_Aliquota { get; set; }
        public double Fiscal_NFS_ICMSST_ReducaoBase { get; set; }
        //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - IPI
        public TabelaCST_IPI Fiscal_NFS_IPI_TabelaCST_IPI { get; set; }
        public double Fiscal_NFS_IPI_ValorAliquota { get; set; }
        public TabelaClasseEnquadramentoIPI Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPI { get; set; }
        public TabelaCodigoEnquadramentoIPI Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPI { get; set; }
        //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - PISCONFIS
        public TabelaCST_PIS_COFINS Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPIS { get; set; }
        public double Fiscal_NFS_PISCOFINS_PIS_ValorAliquota { get; set; }
        public TabelaCST_PIS_COFINS Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINS { get; set; }
        public double Fiscal_NFS_PISCOFINS_COFINS_ValorAliquota { get; set; }

        public GrupoNaturezaReceita_CTS_PIS_COFINS Fiscal_NFS_PISCOFINS_GrupoNaturezaReceita { get; set; }

        public TabelaNaturezaReceita_CTS_PIS_COFINS Fiscal_NFS_PISCOFINS_TabelaNaturezaReceita { get; set; }
        //Detalhes Fiscais - SEP
        public TabelaSpedTipoItem Fiscal_SPED_TabelaSpedTipoItem { get; set; }
        public TabelaSpedCodigoGenero Fiscal_SPED_TabelaSpedCodigoGenero { get; set; }
        public TabelaSpedInformacaoAdicionalItem Fiscal_SPED_TabelaSpedInformacaoAdicionalItem { get; set; }
        //Detalhes Fiscais - Outros.
        public double Fiscal_OutrosPMC { get; set; }
        public double Fiscal_OutrosNVE { get; set; }
        //Detalhes Fiscais - Informações referente das Notas Fiscais de Saída - Percentual Aproximado dos tributos. Decreto 12.741 (De olho no Imposto):
        public double Fiscal_NFS_TributosFederais { get; set; }
        public double Fiscal_NFS_TributosMunicipais { get; set; }
        public double Fiscal_NFS_TributosEstaduais { get; set; }
        public double Fiscal_NFS_TributosTotal { get; set; }
        public double Fiscal_NFS_ValorTributosTotal { get; set; }

        public int Producao_Configuracao_ValidadeDias { get; set; }
        public bool Producao_Configuracao_NaoBaixarComposicaoVenda { get; set; }

        public string FotoEspecificacao_Especificacao { get; set; }
        public string FotoEspecificacao_URL { get; set; }
        public bool FotoEspecificacao_UsarFoto { get; set; }
        public byte[] FotoEspecificacao_Imagem { get; set; }
        public string FotoEspecificacao_Imagem_ContentType { get; set; }


        /* EF Relation */
        public Guid GrupoMercadoriaId { get; set; }
        public Guid SubGrupoMercadoriaId { get; set; }
        public Guid FornecedorId { get; set; }
        public Guid FabricanteId { get; set; }

        public Guid Estoque_UnidadeId { get; set; }
        public Guid Estoque_TributacaoNFCe_TabelaSituacaoTributariaNFCeId { get; set; }
        public Guid Estoque_TributacaoNFCe_TabelaCFOPId { get; set; }
        public Guid Estoque_TributacaoNFCe_TipoServicoFiscalId { get; set; }
        public Guid Fiscal_VinculoFiscalId { get; set; }
        public Guid Fiscal_TipoMercadoriaId { get; set; }
        public Guid Fiscal_TabelaANPId { get; set; }
        public Guid Fiscal_TabelaNCMId { get; set; }
        public Guid Fiscal_TabelaCESTId { get; set; }
        public Guid Fiscal_TabelaOrigemMercadoriaServicoId { get; set; }
        public Guid Fiscal_TabelaCST_CSOSNId { get; set; }
        public Guid Fiscal_TabelaBeneficioSPEDId { get; set; }

        public Guid Fiscal_NFE_TabelaCST_IPIId { get; set; }
        public Guid Fiscal_NFE_TabelaCST_COFINSId { get; set; }
        public Guid Fiscal_NFE_TabelaCST_PISId { get; set; }
        public Guid Fiscal_NFS_ICMS_TabelaModalidadeDeterminacaoBCICMSId { get; set; }
        public Guid Fiscal_NFS_ICMS_TabelaMotivoDesoneracaoICMSId { get; set; }
        public Guid Fiscal_NFS_ICMSST_TabelaModalidadeDeterminacaoBCICMSId { get; set; }
        public Guid Fiscal_NFS_IPI_TabelaCST_IPIId { get; set; }
        public Guid Fiscal_NFS_IPI_TabelaClasseEnquadramentoIPIId { get; set; }
        public Guid Fiscal_NFS_IPI_TabelaCodigoEnquadramentoIPIId { get; set; }
        public Guid Fiscal_NFS_PISCOFINS_PIS_TabelaCSTCOFINSId { get; set; }
        public Guid Fiscal_NFS_PISCOFINS_PIS_TabelaCSTPISId { get; set; }
        public Guid Fiscal_NFS_PISCOFINS_GrupoNaturezaReceitaId { get; set; }
        public Guid Fiscal_NFS_PISCOFINS_TabelaNaturezaReceitaId { get; set; }
        public Guid Fiscal_SPED_TabelaSpedTipoItemId { get; set; }
        public Guid Fiscal_SPED_TabelaSpedCodigoGeneroId { get; set; }
        public Guid Fiscal_SPED_TabelaSpedInformacaoAdicionalItemId { get; set; }
    }
}
