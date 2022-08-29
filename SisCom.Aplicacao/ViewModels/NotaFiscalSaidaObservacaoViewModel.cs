using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class NotaFiscalSaidaObservacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public NotaFiscalSaida NotaFiscalSaida { get; set; }
        public Observacao Observacao { get; set; }
        public string Descricao { get; set; }

        /* EF Relation */
        public Guid? NotaFiscalSaidaId { get; set; }
        public Guid? ObservacaoId { get; set; }
    }
}
