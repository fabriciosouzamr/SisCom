using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class NotaFiscalEntradaMercadoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public NotaFiscalEntrada NotaFiscalEntrada { get; set; }
        public Mercadoria Mercadoria { get; set; }
        public TabelaCFOP CFOP { get; set; }
        public TabelaNCM NCM { get; set; }
        public TabelaCST_CSOSN CST { get; set; }
        public int QuantidadeCaixas { get; set; }
        public int QuantidadeUnitaria { get; set; }
        public decimal PrecoPorCaixas { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PercentualDesconto { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal PrecoTotal { get; set; }
        public decimal PercentualICMS { get; set; }
        public decimal PercentualIPI { get; set; }

        /* EF Relation */
        public Guid? NotaFiscalEntradaId { get; set; }
        public Guid? MercadoriaId { get; set; }
        public Guid? CFOPId { get; set; }
        public Guid? NCMId { get; set; }
        public Guid? CSTId { get; set; }
    }
}
