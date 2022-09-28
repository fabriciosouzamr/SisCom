using Funcoes.Enum;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
	public class NotaFiscalSaidaViewModel
	{
		[Key]
		public Guid Id { get; set; }
		public Empresa Empresa { get; set; }
		public NaturezaOperacao NaturezaOperacao { get; set; }
		public NotaFiscalFinalidade NotaFiscalFinalidade { get; set; }
		public string NotaFiscal { get; set; }
		public DateTime DataEmissao { get; set; }
		public DateTime DataSaida { get; set; }
        public DateTime? DataTransmissao { get; set; }
        public string HoraEmissao { get; set; }
		public string Modelo { get; set; }
		public string Serie { get; set; }
		public string SubSerie { get; set; }
        public NF_Status Status { get; set; }
		public Pessoa Cliente { get; set; }
		public string CNPJ_CPF { get; set; }
		public string IE { get; set; }
		public Endereco? Cliente_Endereco { get; set; }
		public string? Cliente_Telefone { get; set; }
		public string? Cliente_EMail { get; set; }
		public decimal ValorFrete { get; set; }
		public decimal ValorSeguro { get; set; }
		public decimal OutrasDespesas { get; set; }
		public decimal ValorDesconto { get; set; }
		public decimal PercentualDesconto { get; set; }
		public decimal PercentuaAliquotaSimplesNacional { get; set; }
		public Transportadora Transportadora { get; set; }
        public Funcionario Vendedor { get; set; }
        public TipoFrete Transportadora_FreteConta { get; set; }
		public string Transportadora_CNPJ_CPF { get; set; }
		public string Transportadora_Placa { get; set; }
		public Estado Transportadora_UF { get; set; }
		public string Transportadora_RNTRC { get; set; }
		public int Transportadora_NumeroCarga { get; set; }
		public int VolumeTransportados_Quantidade { get; set; }
		public string VolumeTransportados_Especie { get; set; }
		public string VolumeTransportados_Marca { get; set; }
		public int VolumeTransportados_Numero { get; set; }
		public float VolumeTransportados_PesoBruto { get; set; }
		public float VolumeTransportados_PesoLiquido { get; set; }
		public RegimeTributario RegimeTributario { get; set; }
        public string? ObservacaoDocumento { get; set; }
        public string? InformacoesAdicionaisInteresseFisco { get; set; }
        public string? InformacoesComplementaresInteresseContribuinte_Obsersacao { get; set; }
        public Estado? InformacoesComplementaresInteresseContribuinte_UF { get; set; }
        public string? InformacoesComplementaresInteresseContribuinte_Local { get; set; }
        public string? CodigoChaveAcesso { get; set; }
        public string? Protocolo { get; set; }
        public NF_IndicaPresenca IndicaPresenca { get; set; }
        public NF_TipoEmissao TipoEmissao { get; set; }
        public NF_Operacao Operacao { get; set; }
        public string? EmailDestinoXML { get; set; }
        public bool TransmitirCliente { get; set; }
        public bool TransmitirEnderecoCliente { get; set; }
        public string? RetornoSefaz { get; set; }
        public string? RetornoSefazCodigo { get; set; }
        public DateTime? DataRetornoSefaz { get; set; }
        public virtual List<NotaFiscalSaidaMercadoria> NotaFiscalSaidaMercadoria { get; set; }
        public virtual List<NotaFiscalSaidaPagamento> NotaFiscalSaidaPagamento { get; set; }
        public virtual List<NotaFiscalSaidaReferencia> NotaFiscalSaidaReferencia { get; set; }
        public virtual List<NotaFiscalSaidaObservacao> NotaFiscalSaidaObservacao { get; set; }
        public Venda Venda { get; set; }

        /* EF Relation */
        public Guid? EmpresaId { get; set; }
		public Guid? NaturezaOperacaoId { get; set; }
		public Guid? NotaFiscalFinalidadeId { get; set; }
		public Guid? ClienteId { get; set; }
		public Guid? VendedorId { get; set; }
		public Guid? TabelaOrigemVendaId { get; set; }
		public Guid? TransportadoraId { get; set; }
		public Guid? Transportadora_UFId { get; set; }
		public Guid? InformacoesComplementaresInteresseContribuinte_UFId { get; set; }
        public Guid? VendaId { get; set; }
    }
}
