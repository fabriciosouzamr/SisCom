using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class NotaFiscalSaidaPagamentoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public NotaFiscalSaida NotaFiscalSaida { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public DateTime DataVecimento { get; set; }
        public Decimal Valor { get; set; }

        /* EF Relation */
        public Guid? NotaFiscalSaidaId { get; set; }
        public Guid? FormaPagamentoId { get; set; }
    }
}
