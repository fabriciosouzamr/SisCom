using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class FormaPagamento : Entity
    {
        public TipoPagamento TipoPagamento  { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public bool UsaNoPagamento { get; set; }
        public bool UsaNaVenda { get; set; }
        public string NomeInterno { get; set; }

        /* EF Relation */
        public Guid? TipoPagamentoId { get; set; }
    }
}
