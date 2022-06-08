using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class NotaFiscalEntradaFaturaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public NotaFiscalEntrada NotaFiscalEntrada { get; set; }
        public decimal NumeroDocumento { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public bool DuplicataPendente { get; set; }
        public ContaFinanceira ContaFinanceira { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorPago { get; set; }
        public string Observacao { get; set; }
    }
}
