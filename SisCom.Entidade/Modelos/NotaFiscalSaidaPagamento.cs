using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class NotaFiscalSaidaPagamento : Entity
    {
        public NotaFiscalSaida NotaFiscalSaida { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public DateTime DataVecimento { get; set; }
        public Decimal Valor { get; set; }

        /* EF Relation */
        public Guid? NotaFiscalSaidaId { get; set; }
        public Guid? FormaPagamentoId { get; set; }
    }
}
