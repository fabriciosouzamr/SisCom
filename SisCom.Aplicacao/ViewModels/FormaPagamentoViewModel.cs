using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class FormaPagamentoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public bool UsaNoPagamento { get; set; }
        public bool UsaNaVenda { get; set; }
        public string NomeInterno { get; set; }

        /* EF Relation */
        public Guid? TipoPagamentoId { get; set; }
    }
}
