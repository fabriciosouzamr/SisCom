using Funcoes._Entity;
using SisCom.Entidade.Enum;
using System;

namespace SisCom.Entidade.Modelos
{
    public class NotaFiscalEntrada : Entity
    {
        public DateTime DataEntrada { get; set; }
        public DateTime DataEmissao { get; set; }
        public String NotaFiscal { get; set; }
        public NF_Modelo Modelo { get; set; }
        public String Serie { get; set; }
        public Pessoa Fornecedor { get; set; }
        public NaturezaOperacao NaturezaOperacao { get; set; }
        public TipoFrete TipoFrete { get; set; }
        public double PercentualBaseICMSST { get; set; }
        public decimal  ValorICMSST { get; set; }
        public decimal ValorSeguro { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorOutrasDespesas { get; set; }
        public decimal ValorNota { get; set; }
        public string CodigoChaveAcesso { get; set; }
        public Empresa Empresa { get; set; }
        public DateTime? Pedido { get; set; }
        public bool AtualizarPreco { get; set; }
        public bool IgnorarICMSDesonerado { get; set; }
        public double BaseCalculo { get; set; }
        public decimal ValorICMS { get; set; }
        public decimal ValorICMSSubstitucao { get; set; }
        public decimal ValorICMSDesoneracao { get; set; }
        public decimal ValorIPI { get; set; }
        public decimal ValorFCPST { get; set; }
        public int Volumes { get; set; }
        public decimal TotalMercadorias { get; set; }
        public decimal TotalNota { get; set; }
        public TipoDocumentoImportacao? Importacao_TipoDocumentoImportacao { get; set; }
        public string? Importacao_NumeroDocumento { get; set; }
        public string? Importacao_NumeroDrawback { get; set; }
        public decimal Importacao_ValorPIS { get; set; }
        public decimal Importacao_ValorCofins { get; set; }
        public string? ServicosAquisicao_CodigoChaveAcesso { get; set; }
        public string? ServicosAquisicao_Serie { get; set; }
        public string? ServicosAquisicao_SubSerie { get; set; }
        public double ServicosAquisicao_PercentualBasePIS { get; set; }
        public double ServicosAquisicao_AliquotaPIS { get; set; }
        public decimal ServicosAquisicao_ValorPIS { get; set; }
        public double ServicosAquisicao_PercentualBaseCofins { get; set; }
        public double ServicosAquisicao_AliquotaCofins { get; set; }
        public decimal ServicosAquisicao_ValorCofins { get; set; }
        public double ServicosAquisicao_PercentualPISRefFonte { get; set; }
        public double ServicosAquisicao_AliquotaCofinsRetFonte { get; set; }
        public decimal ServicosAquisicao_ValorISS { get; set; }
        public decimal ServicosAquisicao_ValorICMSDesoneracao { get; set; }
        public NF_Finalidade InformacaoAdicionais_Finalidade { get; set; }

        /* EF Relation */
        public Guid? FornecedorId { get; set; }
        public Guid? NaturezaOperacaoId { get; set; }
        public Guid? EmpresaId { get; set; }
    }
}
