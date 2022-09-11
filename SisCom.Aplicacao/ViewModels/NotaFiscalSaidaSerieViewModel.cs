
using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class NotaFiscalSaidaSerieViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Serie { get; set; }
        public string UltimaNotaFiscal { get; set; }
        public NotaFiscalSaida UltimaNotaFiscalSaida { get; set; }

        /* EF Relation */
        public Guid? UltimaNotaFiscalSaidaId { get; set; }
    }
}
